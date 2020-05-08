using Flunt.Notifications;
using System;
using System.Linq;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Results.DashBoard;

namespace AppFullStackDemo.Domain.Handlers
{
    public class DashBoardHandler : Notifiable
    {
        #region Constructor and Internal Variables
        private readonly IEquipmentRepository _equipmentRepository;
        public DashBoardHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        #endregion

        public BaseCommandResult HandleDashBoard(string companyId = "")
        {
            List<Equipment> equipments = new List<Equipment>();
            equipments = _equipmentRepository.GetEquipmentsEnt().ToList();
            var listOfAndroids = new List<GetDashBoardInfo>();
            var listOfManufacturers = new List<GetDashBoardInfo>();

            equipments.ForEach(equip =>
            {
                string manufacturer = equip.DeviceModel.Manufacturer.Description;
                string apiLevel = equip.ApiLevelDesc;
                bool manufacturerFound = false;
                bool apiLevelFound = false;

                listOfManufacturers.ForEach(manuf =>
                {
                    if (manuf.Field == manufacturer)
                    {
                        manufacturerFound = true;
                        manuf.Value = (Convert.ToInt32(manuf.Value) + 1).ToString();
                    }
                });

                listOfAndroids.ForEach(api =>
                {
                    if (api.Field == apiLevel)
                    {
                        apiLevelFound = true;
                        api.Value = (Convert.ToInt32(api.Value) + 1).ToString();
                    }
                });

                if (!manufacturerFound)
                {
                    listOfManufacturers.Add(new GetDashBoardInfo(manufacturer, "1"));
                }

                if (!apiLevelFound)
                {
                    listOfAndroids.Add(new GetDashBoardInfo(apiLevel, "1"));
                }
            });


            //first of all I'll load ALL EquipmentLogs on the last 24h to use it during the forEach

            //organizing data
            listOfAndroids = listOfAndroids.OrderByDescending(p => p.Value).ToList();
            listOfManufacturers = listOfManufacturers.OrderByDescending(p => p.Value).ToList();

            GetDashBoardResult returnData = new GetDashBoardResult(listOfAndroids, listOfManufacturers);
            return new BaseCommandResult(true, "", returnData);
        }
    }
}