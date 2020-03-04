using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Database.Commands.Handlers
{
    // TODO: Remove this handler after test
    public class InitDataCommandHandler : CommandHandler<InitDataCommand>
    {
        private static readonly Random random = new Random();
        private static readonly Dictionary<int, DateTime> dates = new Dictionary<int, DateTime>();

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        static InitDataCommandHandler()
        {
            const int maxMonths = 20;

            for (int i = 1; i <= maxMonths; i++)
            {
                dates.Add(i, DateTime.Today.AddMonths(i - maxMonths));
            }
        }

        public InitDataCommandHandler(DataContext dataContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : base(dataContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        protected override void OnHandling(InitDataCommand command, CancellationToken token)
        {
            if (DataContext.Users.Any())
            {
                Cancel();
                return;
            }

            IdentityRole role = CreateAdminRole();
            Thread.Sleep(1000);

            (ApplicationUser, ApplicationUser) users = CreateUser(role);
            Thread.Sleep(1000);

            List<Equipment> equipments = GetEquipments();
            DataContext.Equipments.AddRange(equipments);
            DataContext.SaveChanges();
            Thread.Sleep(2000);


            List<Request> requests = GetRequests(users);
            DataContext.Requests.AddRange(requests);
            DataContext.SaveChanges();
            Thread.Sleep(2000);

            List<RequestStatusInfo> statuses = GetRequestStatusInfo();
            DataContext.RequestStatusInfo.AddRange(statuses);
            DataContext.SaveChanges();
            Thread.Sleep(2000);

            List<UserEquipment> userEquipments = GetUserEquipments();
            DataContext.UserEquipments.AddRange(userEquipments);
        }

        private IdentityRole CreateAdminRole()
        {
            IdentityRole role = new IdentityRole("admin");

            roleManager
                .CreateAsync(role)
                .Wait();

            return role;
        }

        private (ApplicationUser, ApplicationUser) CreateUser(IdentityRole role)
        {
            ApplicationUser adminUser = new ApplicationUser
            {
                UserName = "arthur.mezhidov@gmail.com",
                Email = "arthur.mezhidov@gmail.com",
                PhoneNumber = "+375 (33) 1234567",
                FirstName = "Arthur",
                LastName = "Mezhidov",
                Country = "BY",
                StateOrProvince = "Minsk",
                Locality = "Minsk",
                Postcode = "567567",
                StreetAddress = "Tolstogo 10",
                CompanyName = "iTechArt Group",
                CompanySite = "www.itechart-group.com",
                Post = "220118",
                About = "Software Developer Software Developer Software Developer Software Developer",
                AvatarUrl = "/assets/media/users/default.jpg",
                SecurityStamp = "ZSKDGPIP7BZQ3MT42X4DIILQVIPEKFIS"
            };

            userManager
                .CreateAsync(adminUser, "t4%tga!d_fT")
                .Wait();

            userManager
                .AddToRoleAsync(adminUser, role.Name)
                .Wait();

            ApplicationUser testUser = new ApplicationUser
            {
                UserName = "test@gmail.com",
                Email = "test@gmail.com",
                PhoneNumber = "+375 (33) 1234567",
                FirstName = "Test",
                LastName = "User",
                Country = "BY",
                StateOrProvince = "Minsk",
                Locality = "Minsk",
                Postcode = "567567",
                StreetAddress = "Tolstogo 10",
                CompanyName = "iTechArt Group",
                CompanySite = "www.itechart-group.com",
                Post = "220118",
                About = "Test user test user",
                AvatarUrl = "/assets/media/users/default.jpg",
                SecurityStamp = "NGJDRE4AZWHQOPYASG2PYS3EHRZYX6ZH"
            };

            userManager
                .CreateAsync(testUser, "t4%tga!d_fT")
                .Wait();

            return (adminUser, testUser);
        }

        private List<Equipment> GetEquipments()
        {
            List<Equipment> list = new List<Equipment>();

            for (int i = 0; i < 500; i++)
            {
                list.Add(new Equipment
                {
                    Name = "Equipment " + i,
                    Price = random.Next(10, 20 + i),
                    Type = (EquipmentType)random.Next(1, 5)
                });
            }

            return list;
        }

        private List<Request> GetRequests((ApplicationUser, ApplicationUser) users)
        {
            List<Request> list = new List<Request>();

            for (int i = 0; i < 800; i++)
            {
                DateTime date = dates[random.Next(1, 20)];

                list.Add(new Request
                {
                    Message = "Message " + i,
                    EquipmentType = (EquipmentType)random.Next(1, 5),
                    UserId = users.Item2.Id,
                    AssignedUserId = users.Item1.Id,
                    RequestedOn = new DateTime(date.Year, date.Month, random.Next(1, 28))
                });
            }

            return list;
        }

        private List<RequestStatusInfo> GetRequestStatusInfo()
        {
            List<Request> requests = DataContext.Requests.Include(r => r.RequestStatusInfos).ToList();
            List<RequestStatusInfo> statuses = new List<RequestStatusInfo>();

            int i = 1;

            foreach (Request request in requests)
            {
                if (request.RequestStatusInfos != null && request.RequestStatusInfos.Any())
                {
                    continue;
                }

                i++;

                statuses.Add(new RequestStatusInfo
                {
                    Status = RequestStatus.Pending,
                    Message = "Pending " + i,
                    RequestId = request.Id,
                    UpdatedAt = request.RequestedOn.AddHours(1),
                    UpdatedBy = request.UserId
                });

                if (random.Next(1, 10) == 6)
                {
                    statuses.Add(new RequestStatusInfo
                    {
                        Status = RequestStatus.Canceled,
                        RequestId = request.Id,
                        Message = "Canceled " + i,
                        UpdatedAt = request.RequestedOn.AddHours(2),
                        UpdatedBy = request.UserId
                    });

                    continue;
                }

                statuses.Add(new RequestStatusInfo
                {
                    Status = RequestStatus.InProgress,
                    RequestId = request.Id,
                    Message = "InProgress " + i,
                    UpdatedAt = request.RequestedOn.AddHours(3),
                    UpdatedBy = request.AssignedUserId
                });

                if (random.Next(1, 10) == 4)
                {
                    statuses.Add(new RequestStatusInfo
                    {
                        Status = RequestStatus.Declined,
                        RequestId = request.Id,
                        Message = "Declined " + i,
                        UpdatedAt = request.RequestedOn.AddHours(4),
                        UpdatedBy = request.AssignedUserId
                    });

                    continue;
                }

                statuses.Add(new RequestStatusInfo
                {
                    Status = RequestStatus.Approved,
                    RequestId = request.Id,
                    Message = "Approved " + i,
                    UpdatedAt = request.RequestedOn.AddHours(5),
                    UpdatedBy = request.AssignedUserId
                });

                statuses.Add(new RequestStatusInfo
                {
                    Status = RequestStatus.Completed,
                    RequestId = request.Id,
                    Message = "Completed " + i,
                    UpdatedAt = request.RequestedOn.AddHours(6),
                    UpdatedBy = request.UserId
                });
            }

            return statuses;
        }

        private List<UserEquipment> GetUserEquipments()
        {
            List<Request> requests = DataContext.Requests.Include(r => r.RequestStatusInfos).ToList();
            List<Equipment> equipments = DataContext.Equipments.ToList();
            List<UserEquipment> lastUserEquipments = DataContext.UserEquipments.ToList();
            List<UserEquipment> list = new List<UserEquipment>();

            foreach (Request request in requests)
            {
                if (lastUserEquipments.Any(r => r.RequestId == request.Id))
                {
                    continue;
                }

                if(request.RequestStatusInfos.Any(s => s.Status == RequestStatus.Completed))
                {
                    Equipment[] currentEquipments = equipments.Where(s => s.Type == request.EquipmentType).ToArray();

                    list.Add(new UserEquipment
                    {
                        ReceivedDate = request.RequestedOn,
                        ExpirationDate = DateTime.Today.AddMonths(random.Next(0, 10)),
                        IsReturned = false,
                        UserId = request.UserId,
                        RequestId = request.Id,
                        EquipmentId = currentEquipments[random.Next(0, currentEquipments.Length - 1)].Id
                    });
                }
            }

            return list;
        }
    }
}
