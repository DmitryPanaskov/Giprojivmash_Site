﻿using System;
using System.Collections.Generic;
using System.Linq;
using Giprojivmash.DAL.Entities;
using Giprojivmash.WEB.Models.Enums;

namespace Giprojivmash.DAL.Context
{
    public static class GiprojivmashInitializer
    {
        public static void InitializerAsync(GiprojivmashContext context)
        {
            Validator(context);
            InitializerServiceFirstLayer(context);
            InitializerServiceSecondLayer(context);
            InitializerServiceThirdLayer(context);
            InitializerContact(context);
            InitializerContactData(context);
        }

        private static void InitializerServiceFirstLayer(GiprojivmashContext context)
        {
            if (!context.ServiceFirstLayers.Any())
            {
                var serviceFirstLayerEntities = new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        Description = "Проектирование зданий и сооружений I и II уровней ответственности",
                        PhotoTitle = "design.png",
                        DescriptionShort = "Комплексные решения в проектировании объектов любой сложности",
                        Title = "Проектирование",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Обоснование инвестиций",
                        PhotoTitle = "engineering.png",
                        DescriptionShort = "Инженерные и консультационные услуги на профессиональном уровне",
                        Title = "Обоснование инвестиций",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Геодезия",
                        PhotoTitle = "geodesy.png",
                        DescriptionShort = "???????????",
                        Title = "Геодезия",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Экология",
                        PhotoTitle = "ecology.png",
                        DescriptionShort = "?????????????",
                        Title = "Экология",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Промышленная безопасность",
                        PhotoTitle = "industrialSafety.png",
                        DescriptionShort = "Проектирование технических устройств применяемых на опасных производственных объектах",
                        Title = "Промышленная безопасность",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Системы безопасности",
                        PhotoTitle = "safety.png",
                        DescriptionShort = "??????????????????",
                        Title = "Системы безопасности",
                    },
                };

                foreach (var item in serviceFirstLayerEntities)
                {
                    context.Set<ServiceFirstLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerServiceSecondLayer(GiprojivmashContext context)
        {
            if (!context.ServiceSecondLayers.Any())
            {
                var serviceSecondLayerEntities = new List<ServiceSecondLayerEntity>
                {
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 1,
                        Description = "1.2 Разработка разделов проектной документации",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 1,
                        Description = "1.3 Управление проектированием с привлечением субподрядных организаций (функции генерального проектировщика).",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 2,
                        Description = "2.1 Геодезические и картографические работы, выполняемые при инженерно-геодезических," +
                        " геологических изысканиях, землеустроительных работах, изысканиях трасс линейных сооружений, иных изысканиях и специальных работах.",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 3,
                        Description = "3.1 Проектирование (конструирование) технических устройств, применяемых на опасных производственных объектах," +
                        " на которых используется оборудование, работающее под давлением (трубопроводы пара и горячей воды III категории).",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 3,
                        Description = "3.2 Проектирование объектов газораспределительной системы и газопотребления;",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 3,
                        Description = "3.3 Проектирование (разработка технологического раздела) котельных;",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 3,
                        Description = "3.4 Проектирование радиационных объектов (рентгеновские кабинеты медицинского назначения," +
                        " помещения для гамма-установок, рентгенодиагностические лаборатории).",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 5,
                        Description = "5.1 Охрана юридическим лицом принадлежащих ему объектов (имущества);" +
                        " проектирование средств и систем охраны (за исключением средств индивидуального пользования).",
                    },
                };

                foreach (var item in serviceSecondLayerEntities)
                {
                    context.Set<ServiceSecondLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerServiceThirdLayer(GiprojivmashContext context)
        {
            if (!context.ServiceThirdLayers.Any())
            {
                var serviceThirdLayerEntities = new List<ServiceThirdLayerEntity>
                {
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- производственные здания и сооружения и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- сельскохозяйственные здания и сооружения и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- жилые здания и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- общественные здания и сооружения и их комплексы.",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- генеральный план и транспорт;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- архитектурные решения;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- строительные решения;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- инженерное оборудование, сети и системы (тепло-, холодо-, водо-, газоснабжения, канализации," +
                        " отопления, вентиляции и кондиционирования воздуха, электроснабжения, электрооборудования, электроосвещения, связи, радиофикации и телевидения);",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- специальные разделы (охрана окружающей среды, инженерно-технические мероприятия гражданской обороны, мероприятия по предупреждению " +
                        "чрезвычайных ситуаций, организация строительства, защита строительных конструкций от коррозии);",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- технологические решения.",
                    },
                };

                foreach (var item in serviceThirdLayerEntities)
                {
                    context.Set<ServiceThirdLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerContact(GiprojivmashContext context)
        {
            if (!context.Contact.Any())
            {
                var contactEntities = new List<ContactEntity>
                {
                    new ContactEntity
                    {
                        FirstName = "Гипроживмаш",
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerContactData(GiprojivmashContext context)
        {
            if (!context.Contact.Any())
            {
                var contactEntities = new List<ContactDataEntity>
                {
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         Type = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-50-30",
                         SubData = "+375232535030",
                         Type = ContactDataType.Fax,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         Type = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         Type = ContactDataType.VK,
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactDataEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
