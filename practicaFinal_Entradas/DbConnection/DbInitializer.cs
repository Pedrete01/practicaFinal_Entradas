using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using practicaFinal_Entradas.Entities;
using System.Collections.Generic;

namespace practicaFinal_Entradas.DbConnection
{
    public class DbInitializer
    {
        private readonly EntradasDbContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<Usuarios> _userManager;

        public DbInitializer(EntradasDbContext ctx, IWebHostEnvironment hosting, UserManager<Usuarios> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            Usuarios usuario = await _userManager.FindByEmailAsync("pedrete01@gmail.com");

            if (usuario == null)
            {
                usuario = new Usuarios()
                {
                    Nombre = "Pedro",
                    Apellidos = "Abad Valero",
                    Email = "pedrete01@gmail.com",
                    UserName = "Pedrete01"
                };

                var result = await _userManager.CreateAsync(usuario, "12345_Aa");
                if (result != IdentityResult.Success)
                {
                    Console.WriteLine(result);
                    throw new InvalidOperationException("No se ha podido registrar al usuario");
                }
            }

            if (!_ctx.Categorias.Any())
            {
                _ctx.Categorias.AddRange(Categorias.Select(c => c.Value));
            }

            if (!_ctx.Entradas.Any())
            {
                _ctx.AddRange(
                    new Entrada { entradaName = "Mercury Tour", entradaDescripCorta = "Concierto de Imagine Dragons.", entradaDescripLarga = "Concierto de Imagine Dragons en Santiago de Compostela. Nuevo Album Mercury ya disponible.", precio = 90.50M, fecha = "11/07/2023", imagen = "https://cttouringid.com/wp-content/uploads/2021/09/TR_NationalAsset_ImagineDragons_SG_1080x1080-768x768.jpg", ubicacion = "Monte Do Gozo", ciudad = "Santiago de Compostela", pais = "Spain", stock = 12000, vendidas = 1250, categoriaId = 1, categoria = Categorias["Conciertos"] },
                    new Entrada { entradaName = "Fight or Flight Tour", entradaDescripCorta = "Concierto de Kaleo.", entradaDescripLarga = "Concierto de Kaleo en Madrid. Nuevo Album Surface Sounds ya disponible.", precio = 34.50M, fecha = "27/09/2023", imagen = "https://livesticket.com/wp-content/uploads/2021/11/35841-kaleo-fight-or-flight-tour.jpg", ubicacion = "Sala la Riviera", ciudad = "Madrid", pais = "Spain", stock = 2000, vendidas = 1300, categoriaId = 1, categoria = Categorias["Conciertos"] },
                    new Entrada { entradaName = "The OK Orchestra Tour", entradaDescripCorta = "Concierto de AJR.", entradaDescripLarga = "Concierto de AJR en París. Nuevo Album OK Orchestra ya disponible.", precio = 24.90M, fecha = "9/10/2023", imagen = "https://th.bing.com/th/id/OIP.Ijxhes8SXN1CiVpEE-XbrwHaHa?pid=ImgDet&rs=1", ubicacion = "Le Trianon", ciudad = "París", pais = "France", stock = 1800, vendidas = 98, categoriaId = 1, categoria = Categorias["Conciertos"] },
                    new Entrada { entradaName = "Samsung RV", entradaDescripCorta = "Evento de Samsung.", entradaDescripLarga = "Evento de Samsung en Barcelona. Ven a visitar el evento más grande de RV.", precio = 10M, fecha = "12/02/2023", imagen = "https://th.bing.com/th/id/OIP.cNHWQJQ3ziz5zi3AnoJgcQHaEJ?pid=ImgDet&rs=1", ubicacion = "N26 Tech", ciudad = "Barcelona", pais = "Spain", stock = 20000, vendidas = 504, categoriaId = 2, categoria = Categorias["Eventos"] },
                    new Entrada { entradaName = "Motor Expo", entradaDescripCorta = "Evento de coches y motos.", entradaDescripLarga = "Evento de coches y motos en Alicante.", precio = 6.45M, fecha = "23/03/2023", imagen = "https://th.bing.com/th/id/R.c31dd892559d777d010b0c0938893f7a?rik=hR3LXrCrgYOk0g&riu=http%3a%2f%2fwww.theleader.info%2fwp-content%2fuploads%2f2019%2f05%2fantic-auto-foto-600x400.jpg&ehk=a4AS5HoNTveiM4IvXeB7GhjR31T6OCJZSQHC%2fjEcdu8%3d&risl=&pid=ImgRaw&r=0", ubicacion = "IFA", ciudad = "Alicante", pais = "Spain", stock = 4500, vendidas = 430, categoriaId = 2, categoria = Categorias["Eventos"] },
                    new Entrada { entradaName = "Mobile Expo", entradaDescripCorta = "Evento de móviles", entradaDescripLarga = "Evento de móviles en Berlín. Los dispositivos más recientes en un solo evento.", precio = 20M, fecha = "30/04/2023", imagen = "https://i.pinimg.com/originals/98/d0/bb/98d0bb988fb9ffc0b3883e64d1cd265f.jpg", ubicacion = "IFA Berlín", ciudad = "Berlín", pais = "Germany", stock = 15000, vendidas = 1004, categoriaId = 2, categoria = Categorias["Eventos"] },
                    new Entrada { entradaName = "Real Madrid vs FC Barcelona", entradaDescripCorta = "Futbol - Real Madrid vs FC Barcelona.", entradaDescripLarga = "Partido Real Madrid vs FC Barcelona. El clásico está de vuelta.", precio = 120.36M, fecha = "21/03/2023", imagen = "https://aws-tiqets-cdn.imgix.net/images/content/0865eeb22d704076aca1b33306828401.jpg?auto=format&fit=crop&ixlib=python-3.2.1&q=70&s=62f9b74fceda2938f6467a268c7bdc29", ubicacion = "Estadio Santiago Bernabeu", ciudad = "Madrid", pais = "Spain", stock = 26000, vendidas = 2680, categoriaId = 3, categoria = Categorias["Deportes"] },
                    new Entrada { entradaName = "Hercules CF vs Elche FC", entradaDescripCorta = "Futbol - Hercules CF vs Elche FC.", entradaDescripLarga = "Partido Hercules CF vs Elche FC. El derbi alicantino de nuevo.", precio = 25.99M, fecha = "21/01/2023", imagen = "https://cadenaser00.epimg.net/ser/imagenes/2020/05/11/radio_alicante/1589211281_623545_1589211724_noticia_normal.jpg", ubicacion = "Estadio Rico Pérez", ciudad = "Alicante", pais = "Spain", stock = 15000, vendidas = 2250, categoriaId = 3, categoria = Categorias["Deportes"] },
                    new Entrada { entradaName = "España vs Francia", entradaDescripCorta = "Baloncesto - España vs Francia.", entradaDescripLarga = "Partido España vs Francia en el Palau Sant Jordi.", precio = 60.50M, fecha = "20/07/2023", imagen = "https://www.taquilla.com/data/images/t/9b/palau-sant-jordi.jpg", ubicacion = "Palau Sant Jordi", ciudad = "Barcelona", pais = "Spain", stock = 15400, vendidas = 470, categoriaId = 3, categoria = Categorias["Deportes"] }
                );
            }

            _ctx.SaveChanges();
        }

        private static Dictionary<string, Categoria>? categorias;

        public static Dictionary<string, Categoria> Categorias
        {
            get
            {
                if (categorias == null)
                {
                    var genresList = new Categoria[]
                    {
                        new Categoria{Name="Conciertos", CategoriaDescrip="Toda la música y conciertos en un único sitio."},
                        new Categoria{Name="Eventos", CategoriaDescrip="Todos los eventos en un único sitio."},
                        new Categoria{Name="Deportes", CategoriaDescrip="Todo el deporte en un único sitio."}
                    };

                    categorias = new Dictionary<string, Categoria>();

                    foreach (Categoria genre in genresList)
                    {
                        categorias.Add(genre.Name, genre);
                    }
                }

                return categorias;
            }
        }
    }
}
