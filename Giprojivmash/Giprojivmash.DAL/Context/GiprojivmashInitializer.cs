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

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
