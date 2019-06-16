using BicycleService.Data.Sql.DAO;
using BicycleService.Utils.DoubleRandom;
using BicycleService.Utils.Enums;
using System;
using System.Collections.Generic;

namespace BicycleService.Data.Sql.Migrations
{
    public class ListBuilder
    {
        public IEnumerable<DAO.User> BuildUserList()
        {
            var userList = new List<DAO.User>();
            var user = new DAO.User()
            {
                UserId = 1,
                UserName = "Sebastian",
                UserEmail = "s.siwik@student.po.edu.pl",
                Address = "Opole, ul. Kawowa 55",
                RegistrationDate = new DateTime(2018, 12, 31),
                BirthDate = new DateTime(1998, 11, 11),
                IsBannedUser = false,
                UserStatus = UserStatus.Admin.ToString()
            };
            userList.Add(user);

            for (int i = 2; i < 21; i++)
            {
                var user2 = new DAO.User()
                {
                    UserId = i,
                    UserName = "User" + i,
                    UserEmail = $"user{i}@student.po.edu.pl",
                    Address = $"Opole, ul. Przykładowa {i}",
                    RegistrationDate = DateTime.Now.AddMonths(-2),
                    BirthDate = DateTime.Now.AddYears(-15 - i),
                    IsBannedUser = false,
                    UserStatus = UserStatus.User.ToString()
                };
                userList.Add(user2);
            }
            return userList;
        }
        public IEnumerable<Bicycle> BuildBicycleList(IEnumerable<DAO.User> userList)
        {
            var bicycleList = new List<Bicycle>();
            foreach (var user in userList)
            {
                for (int i = 0; i < (user.UserId % 2 == 0 ? 2 : 1); i++)
                {
                    var bicycle = new Bicycle()
                    {
                        BicycleId = bicycleList.Count + 1,
                        UserId = user.UserId,
                        ProductionDate = DateTime.Now.AddYears(-user.UserId - i),
                        Type = ((BicycleType)(new Random().Next(14))).ToString()
                    };
                    bicycleList.Add(bicycle);
                }
            }
            return bicycleList;
        }
        public IEnumerable<Workshop> BuildWorkshopList()
        {
            var workshopList = new List<Workshop>();
            for (int i = 1; i < 6; i++)
            {
                var workshop = new Workshop()
                {
                    WorkshopId = i,
                    Address = $"Opole, ul. Rowerowa 2{i}",
                    EmployeeCount = 10 + i
                };
                workshopList.Add(workshop);
            }
            return workshopList;
        }
        public IEnumerable<Service> BuildServiceList(IEnumerable<DAO.User> userList)
        {
            var serviceList = new List<Service>();
            foreach (var user in userList)
            {
                for (int i = 0; i < 2; i++)
                {
                    var service = new Service()
                    {
                        ServiceId = serviceList.Count + 1,
                        UserId = user.UserId,
                        WorkshopId = new Random().Next(1, 6),
                        Price = new Random().Next(20, 301).AddRandomFraction(),
                        Date = DateTime.Now.AddMonths(-1).AddDays(serviceList.Count)
                    };
                    serviceList.Add(service);
                }
            }
            return serviceList;
        }
        public IEnumerable<Fault> BuildFaultList(IEnumerable<Bicycle> bicycleList, IEnumerable<Service> serviceList)
        {
            var faultList = new List<Fault>();
            int checker = 3;
            int bicycleId = 1;
            foreach (var service in serviceList)
            {
                for (int i = 0; i < 2; i++)
                {
                    var fault = new Fault()
                    {
                        FaultId = faultList.Count + 1,
                        BicycleId = service.ServiceId == checker ? bicycleId + 1 : (service.ServiceId == checker + 1 ? bicycleId + 2 : bicycleId),
                        ServiceId = service.ServiceId,
                        FaultDescription = i == 0 ? "Problems with slowing down" : "Pedaling does nothing",
                        FaultCircumstances = "",
                        InvolvedPart = i == 0 ? "brakes" : "chain"
                    };
                    faultList.Add(fault);
                }
                if (service.ServiceId == checker + 1)
                {
                    bicycleId += 3;
                    checker += 4;
                }
            }
            return faultList;
        }
    }
}
