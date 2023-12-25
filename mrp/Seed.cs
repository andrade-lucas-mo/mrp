﻿using mrp.Data;
using mrp.Models;
using System.Linq;

namespace mrp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Hierarchies.Any())
            {
                var Product = new Product()
                {
                    Name = "Ducati Desmosedici",
                    Code = "D162008",
                };

                var Material = new Material()
                {
                    Name = "Ducati Desmosedici Fender",
                    Code = "DDSFD4629",
                    Stock = new Stock()
                    {
                        Qtd = 30
                    },
                    Needs = new List<Need>()
                    {
                        new Need()
                        {
                            Qtd = 10,
                            DoDate = new DateTime(2025,1,1)
                        },
                        new Need()
                        {
                            Qtd = 2,
                            DoDate = new DateTime(2025,1,2)
                        }
                    },
                    Transits = new List<Transit>()
                    {
                        new Transit()
                        {
                            Qtd = 6,
                            Supplier = "Inside Fabric",
                            DoDate = new DateTime(2025,1,5),
                            CreatedDate = new DateTime(2023,11,12)
                        }
                    }
                };

                var hierarchies = new List<Hierarchy>()
                {
                    new Hierarchy()
                    {
                        Material = new Material()
                        {
                            Name = "Carbon fibre",
                            Code = "CF078",
                            Stock = new Stock()
                            {
                                Qtd = 250
                            },
                            Needs = new List<Need>()
                            {
                                new Need()
                                {
                                    Qtd = 100,
                                    DoDate = new DateTime(2025,1,1)
                                },
                                new Need()
                                {
                                    Qtd = 50,
                                    DoDate = new DateTime(2025,1,2)
                                }
                            },
                            Transits = new List<Transit>()
                            {
                                new Transit()
                                {
                                    Qtd = 250,
                                    Supplier = "Premier Carbon Fiber",
                                    DoDate = new DateTime(2025,1,1),
                                    CreatedDate = new DateTime(2023,11,12)
                                }
                            }
                        },
                        MaterialFather = Material,
                        Product = Product,
                        Qtd = 150,
                        Level = 2
                    },
                    new Hierarchy()
                    {
                        Material = Material,
                        Product = Product,
                        Qtd = 1,
                        Level = 1
                    },
                };

                dataContext.Hierarchies.AddRange(hierarchies);
                dataContext.Materials.Add(Material);
                dataContext.Products.Add(Product);
                dataContext.SaveChanges();
            }
        }
    }
}