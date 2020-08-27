using System;
using System.Collections.Generic;
using System.Linq;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;

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
            InitializerDepartment(context);
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
                        Description = "Инженерно-геодезические изыскания",
                        PhotoTitle = "geodesy.png",
                        DescriptionShort = "Инженерно-геодезические изыскания с использованием высокоточное оборудование и современное програмное обеспечение",
                        Title = "Инженерно-геодезические изыскания",
                    },
                    new ServiceFirstLayerEntity
                    {
                        Description = "Инженерно-экологические изыскания",
                        PhotoTitle = "ecology.png",
                        DescriptionShort = "Инженерно-экологические изыскания с использованием современного оборудование и современное програмное обеспечение",
                        Title = "Инженерно-экологические изыскания",
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
                        Description = "Проектирование систем пожаробезопасности и систем охраны",
                        PhotoTitle = "safety.png",
                        DescriptionShort = "Проектирование систем пожаробезопасности и систем охраны",
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
                        Description = "1.1 Разработка проектной документации для строительства следующих видов зданий и сооружений I и II уровней ответственности:",
                    },
                    new ServiceSecondLayerEntity
                    {
                        ServiceFirstLayerId = 1,
                        Description = "1.2 Разработка разделов проектной документации:",
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S138:Functions should not have too many lines of code", Justification = "<>")]
        private static void InitializerContact(GiprojivmashContext context)
        {
            if (!context.Contacts.Any())
            {
                var contactEntities = new List<ContactEntity>
                {
                    new ContactEntity
                    {
                        // id = 1
                        FirstName = "ОАО Гипроживмаш",
                        Position = "Приемная",
                        PositionType = PositionType.General,
                    },
                    new ContactEntity
                    {
                        // id = 2
                        Position = "Директор",
                        FirstName = "Дмитрий",
                        LastName = "Шило",
                        Patronymic = "Иванович",
                        PositionType = PositionType.Manager,
                        Photo = "director.png",
                    },
                    new ContactEntity
                    {
                        // id = 3
                        Position = "Главный инженер",
                        FirstName = "Екатерина",
                        LastName = "Шаповалова",
                        Patronymic = "Игоревна",
                        PositionType = PositionType.Manager,
                    },
                    new ContactEntity
                    {
                        // id = 4
                        Position = "Заместитель главного инженера",
                        FirstName = "Юрий",
                        LastName = "Дубов",
                        Patronymic = "Александрович",
                        PositionType = PositionType.Manager,
                    },
                    new ContactEntity
                    {
                        // id = 5
                        Position = "ГИП",
                        FirstName = "Грибанов",
                        LastName = "Евгений",
                        Patronymic = "Юрьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 6
                        Position = "ГИП",
                        FirstName = "Ковалев",
                        LastName = "Сергей",
                        Patronymic = "Валерьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 7
                        Position = "ГИП",
                        FirstName = "Марочкин",
                        LastName = "Анатолий",
                        Patronymic = "Вячеславович",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 8
                        Position = "ГИП",
                        FirstName = "Петренко",
                        LastName = "Ирина",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 9
                        Position = "Бухгалтерия",
                        FirstName = "Елена",
                        LastName = "Черноокая",
                        Patronymic = "Герасимовна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 10
                        Position = "Юрисконсульт",
                        FirstName = "Ольга",
                        LastName = "Игнатова",
                        Patronymic = "Васильевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 11
                        Position = "Отдел кадров",
                        FirstName = "Жанна",
                        LastName = "Кричевская",
                        Patronymic = "Анатольевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 12
                        Position = "Планово-производственный отдел",
                        FirstName = "Ольга",
                        LastName = "Игнатова",
                        Patronymic = "Васильевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 13
                        Position = "Отдел генплана",
                        FirstName = "Нина",
                        LastName = "Щербатенко",
                        Patronymic = "Павловна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 14
                        Position = "Архитектурно-планировочный отдел",
                        FirstName = "Александра",
                        LastName = "Горбатовская",
                        Patronymic = "Владимировна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 15
                        Position = "Строительный отдел",
                        FirstName = "Владимир",
                        LastName = "Шкундалев",
                        Patronymic = "Петрович",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 16
                        Position = "Сметно-экономический отдел",
                        FirstName = "Наталья",
                        LastName = "Цилько",
                        Patronymic = "Павловна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 17
                        Position = "Отдел электроснабжения и электроосвещения",
                        FirstName = "Андрей",
                        LastName = "Сиротко",
                        Patronymic = "Евгеньевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 18
                        Position = "Отдел автоматизации и слаботочных систем",
                        FirstName = "Петр",
                        LastName = "Комар",
                        Patronymic = "Анатольевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 20
                        Position = "Отдел водоснабжения и канализации",
                        FirstName = "Лариса",
                        LastName = "Мураль",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 19
                        Position = "Отдел теплоснабжения, газоснабжения и вентиляции",
                        FirstName = "Андрей",
                        LastName = "Судаков",
                        Patronymic = "Григорьевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 20
                        Position = "Технологический отдел",
                        FirstName = "Светлана",
                        LastName = "Россол",
                        Patronymic = "Григорьевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 21
                        Position = "Отдел качества и выпуска проектной продукции",
                        FirstName = "Александр",
                        LastName = "Гончаров",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S138:Functions should not have too many lines of code", Justification = "<>")]
        private static void InitializerContactData(GiprojivmashContext context)
        {
            if (!context.ContactDatas.Any())
            {
                var contactEntities = new List<ContactDataEntity>
                {
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-50-30",
                         SubData = "+375232535030",
                         ContactDataType = ContactDataType.Fax,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         ContactDataType = ContactDataType.VK,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 2,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 3,
                         Data = "+375 232 53-27-05",
                         SubData = "+375232532705",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 2,
                         Data = "DmitryShilo@gipro.gomel.by",
                         SubData = "DmitryShilo@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                      ContactId = 3,
                      Data = "EkaterinaShapovalova@gipro.gomel.by",
                      SubData = "EkaterinaShapovalova@gipro.gomel.by",
                      ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 4,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 4,
                         Data = "YuriDubov@gipro.gomel.by",
                         SubData = "YuriDubov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 5,
                         Data = "+375 232 53-27-32",
                         SubData = "+375232532732",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 6,
                         Data = "+375 232 53-61-09",
                         SubData = "+375232536109",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 7,
                         Data = "+375 232 53-27-39",
                         SubData = "+375232532739",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 8,
                         Data = "+375 232 53-61-07",
                         SubData = "+375232536107",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactDataEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerDepartment(GiprojivmashContext context)
        {
            if (!context.Departments.Any())
            {
                var departmentEntities = new List<DepartmentEntity>
                {
                    new DepartmentEntity
                    {
                        // id = 1
                        Name = "Общие",
                    },
                    new DepartmentEntity
                    {
                        // id = 2
                        Name = "Руководство",
                    },
                    new DepartmentEntity
                    {
                        // id = 3
                      Name = "Главные инженеры проекта",
                    },
                    new DepartmentEntity
                    {
                        // id = 4
                      Name = "Отдел кадров",
                    },
                    new DepartmentEntity
                    {
                        // id = 5
                      Name = "Бухгалтерия",
                    },
                    new DepartmentEntity
                    {
                        // id = 6
                      Name = "Планово-производственный отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 7
                      Name = "Отдел генплана",
                    },
                    new DepartmentEntity
                    {
                        // id = 8
                      Name = "Архитектурно-планировочный отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 9
                      Name = "Строительынй отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 10
                      Name = "Отдел электроснабжения и электроосвещения",
                    },
                    new DepartmentEntity
                    {
                        // id = 11
                      Name = "Отдел автоматизации и слаботочных систем",
                    },
                    new DepartmentEntity
                    {
                        // id = 12
                      Name = "Отдел водоснабжения и канализации",
                    },
                    new DepartmentEntity
                    {
                        // id = 13
                      Name = "Отдел тепноснабжения, газоснабжения и вентиляции",
                    },
                    new DepartmentEntity
                    {
                        // id = 14
                      Name = "Технологический отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 15
                      Name = "Отдел качества и выпуска проектной документации",
                    },
                };

                foreach (var item in departmentEntities)
                {
                    context.Set<DepartmentEntity>().Add(item);
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
