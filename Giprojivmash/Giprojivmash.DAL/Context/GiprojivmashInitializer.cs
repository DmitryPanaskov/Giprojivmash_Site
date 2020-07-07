using System;
using System.Collections.Generic;
using System.Linq;
using Giprojivmash.DAL.Entities;

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
        }

        private static void InitializerServiceFirstLayer(GiprojivmashContext context)
        {
            if (!context.ServiceFirstLayers.Any())
            {
                var serviceFirstLayerEntities = new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        Description = "1 Проектирование и строительство зданий и сооружений I и II уровней ответственности и проведение инженерных изысканий для этих целей.",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "2 Работы и услуги, составляющие геодезическую и картографическую деятельность специального назначения:",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "3 Осуществление деятельности в области промышленной безопасности:",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "4 Осуществление деятельности по обеспечению пожарной безопасности.",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "5 Осуществление деятельности по обеспечению безопасности юридических и физических лиц:",
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

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
