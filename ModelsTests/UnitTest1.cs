using Models.ConnectionDB;
using Models.Managers;

namespace ModelsTests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //    AppDbContext.Instancia.setEntorno("Test");
        //}

        //// Adminisitradores
        //[Test]
        //public void Test1()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 1234567, new DateTime(2003, 11, 28), "Payro", 1856, "tatata@gmail.com", "Bruno123", "Bruno123");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}

        //[Test]
        //public void Test2()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 12345678, new DateTime(2010, 11, 28), "Payro", 1856, "tatata@gmail.com", "Bruno123", "bruno12");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}

        //[Test]
        //public void Test3()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 12345678, new DateTime(2003, 11, 28), "Payro", 1856, "tatata", "Bruno123", "Bruno123");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}

        //[Test]
        //public void Test4()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 12345678, new DateTime(2003, 11, 28), "Payro", 1856, "tatata@gmail.com", "bruno", "bruno");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}

        //[Test]
        //public void Test5()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 12345678, new DateTime(2003, 11, 28), "Payro", 1856, "tatata@gmail.com", "Bruno123", "bruno12");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}
        //[Test]
        //public void Test6()
        //{
        //    AdministradorMG.Instancia.Add("Br8no", "Co98mba", 12345678, new DateTime(2003, 11, 28), "Payro", 1856, "tatata@gmail.com", "Bruno123", "Bruno123");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}
        //[Test]
        //public void Test7()
        //{
        //    AdministradorMG.Instancia.Add("Bruno", "Comba", 45414815, new DateTime(2003, 11, 28), "Payro", 1856, "brcomba9@gmail.com", "Bruno123", "Bruno123");

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 1);
        //}

        //[Test]
        //public void Test8()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateNombres(45414815, "Bruno", "Riquelme");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Nombre == "Bruno" && admiMod.Apellido == "Riquelme");
        //}

        //[Test]
        //public void Test9()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateNombres(45414815, "Br4no", "Ri7elme");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Nombre == "Br4no" && admiMod.Apellido == "Ri7elme");
        //}

        //[Test]
        //public void Test10()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateNombres(12345678, "Bruno", "Riquelme");
        //    var admiMod = AdministradorMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(admiMod.Nombre == "Br4no" && admiMod.Apellido == "Ri7elme");
        //}

        //[Test]
        //public void Test11()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateDireccion(45414815, "Av Richieri", 702);
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Calle == "Av Richieri" && admiMod.Altura == 702);
        //}

        //[Test]
        //public void Test12()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateDireccion(45414815, "Av Ric12ieri", 702);
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Calle == "Av Ric12ieri" && admiMod.Altura == 702);
        //}

        //[Test]
        //public void Test13()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateDireccion(12345678, "Av Richieri", 702);
        //    var admiMod = AdministradorMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(admiMod.Calle == "Av Richieri" && admiMod.Altura == 702);
        //}

        //[Test]
        //public void Test14()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateFechaNacimiento(45414815, new DateTime(2000, 11, 28));
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.fechaNacimiento == new DateTime(2000, 11, 28));
        //}

        //[Test]
        //public void Test15()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateFechaNacimiento(45414815, new DateTime(2015, 11, 28));
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.fechaNacimiento == new DateTime(2015, 11, 28));
        //}

        //[Test]
        //public void Test16()
        //{
        //    var modNombres = AdministradorMG.Instancia.UpdateFechaNacimiento(12345678, new DateTime(2000, 11, 28));
        //    var admiMod = AdministradorMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(admiMod.fechaNacimiento == new DateTime(2000, 11, 28));
        //}

        //[Test]
        //public void Test17()
        //{
        //    AdministradorMG.Instancia.UdpateUsuario(45414815, "brunoices@gmail.com");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Email == "brunoices@gmail.com");
        //}

        //[Test]
        //public void Test18()
        //{
        //    AdministradorMG.Instancia.UdpateUsuario(45414815, "brunoicesgmail.com");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Email == "brunoicesgmail.com");
        //}

        //[Test]
        //public void Test19()
        //{
        //    AdministradorMG.Instancia.UdpateUsuario(45414815, "brunoices@gmailcom");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Email == "brunoices@gmailcom");
        //}

        //[Test]
        //public void Test20()
        //{
        //    AdministradorMG.Instancia.UdpateUsuario(45414815, "brunoices@gmail.");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Email == "brunoices@gmail.");
        //}

        //[Test]
        //public void Test21()
        //{
        //    AdministradorMG.Instancia.UdpateUsuario(12345678, "brunoices@gmail.com");
        //    var admiMod = AdministradorMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(admiMod.Email == "brunoicesgmail.com");
        //}

        //[Test]
        //public void Test22()
        //{
        //    AdministradorMG.Instancia.UpdatePassword(45414815, "ices123", "ices123");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Password == "ices123");
        //}

        //[Test]
        //public void Test23()
        //{
        //    AdministradorMG.Instancia.UpdatePassword(45414815, "ices", "ices");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Password == "ices");
        //}

        //[Test]
        //public void Test24()
        //{
        //    AdministradorMG.Instancia.UpdatePassword(45414815, "Ices123", "Ices");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Password == "Ices123");
        //}

        //[Test]
        //public void Test25()
        //{
        //    AdministradorMG.Instancia.UpdatePassword(45414815, "Ices123", "Ices123");
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod.Password == "Ices123");
        //}

        //[Test]
        //public void Test26()
        //{
        //    AdministradorMG.Instancia.UpdatePassword(12345678, "Ices123", "Ices123");
        //    var admiMod = AdministradorMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(admiMod.Email == "brunoicesgmail.com");
        //}

        //[Test]
        //public void Test27()
        //{
        //    AdministradorMG.Instancia.UpdateDNI(45414815, 4488899);
        //    var admiMod = AdministradorMG.Instancia.Buscar(4488899);

        //    Assert.IsTrue(admiMod != null);
        //}

        //[Test]
        //public void Test28()
        //{
        //    AdministradorMG.Instancia.UpdateDNI(45414815, 45414815);
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod != null);
        //}

        //[Test]
        //public void Test29()
        //{
        //    AdministradorMG.Instancia.UpdateDNI(45414815, 44888999);
        //    var admiMod = AdministradorMG.Instancia.Buscar(44888999);

        //    Assert.IsTrue(admiMod != null);
        //}

        //[Test]
        //public void Test30()
        //{
        //    AdministradorMG.Instancia.UpdateDNI(44888999, 45414815);
        //    var admiMod = AdministradorMG.Instancia.Buscar(45414815);

        //    Assert.IsTrue(admiMod != null);
        //}

        //[Test]
        //public void Test31()
        //{
        //    AdministradorMG.Instancia.Delete(12345678);

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 0);
        //}
        //[Test]
        //public void Test32()
        //{
        //    AdministradorMG.Instancia.Delete(45414815);

        //    Assert.IsTrue(AppDbContext.Instancia.Administradores.Count() == 0);
        //}


        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Clientes

        //[Test]
        //public void Test33()
        //{
        //    ClienteMG.Instancia.Add("Roberto Jose", "Carlos", 4038764, new DateTime(2003, 11, 28), "Payro", 1856, 3493662312);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 1);
        //}

        //[Test]
        //public void Test34()
        //{
        //    ClienteMG.Instancia.Add("Roberto Jose", "Carlos", 40387649, new DateTime(2003, 11, 28), "Payro", 1856, 349366231);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 1);
        //}


        //[Test]
        //public void Test35()
        //{
        //    ClienteMG.Instancia.Add("Roberto Jose", "Carlos", 40387649, new DateTime(2016, 11, 28), "Payro", 1856, 3493662312);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 1);
        //}

        //[Test]
        //public void Test36()
        //{
        //    ClienteMG.Instancia.Add("Rob3rt50 Jose", "Car7os", 40387649, new DateTime(2003, 11, 28), "Payro", 1856, 3493662312);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 1);
        //}

        //[Test]
        //public void Test37()
        //{
        //    ClienteMG.Instancia.Add("Roberto Jose", "Carlos", 40387649, new DateTime(2003, 11, 28), "Payro", 1856, 3493662312);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 1);
        //}

        //[Test]
        //public void Test38()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateNombres(12345678, "Diego Armando", "Maradona");
        //    var cliMod = ClienteMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(cliMod.Nombre == "Diego Armando" && cliMod.Apellido == "Maradona");
        //}

        //[Test]
        //public void Test39()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateNombres(40387649, "Di!36o Armando", "Mara3!d");
        //    var cliMod = ClienteMG.Instancia.Buscar(40387649);

        //    Assert.IsTrue(cliMod.Nombre == "Diego Armando" && cliMod.Apellido == "Maradona");
        //}

        //[Test]
        //public void Test40()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateNombres(40387649, "Diego Armando", "Maradona");
        //    var cliMod = ClienteMG.Instancia.Buscar(40387649);

        //    Assert.IsTrue(cliMod.Nombre == "Diego Armando" && cliMod.Apellido == "Maradona");
        //}

        //[Test]
        //public void Test41()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDNI(40387649, 1234567);
        //    var cliMod = ClienteMG.Instancia.Buscar(1234567);

        //    Assert.IsTrue(cliMod != null);
        //}

        //[Test]
        //public void Test42()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDNI(40387649, 40387649);
        //    var cliMod = ClienteMG.Instancia.Buscar(40387649);

        //    Assert.IsTrue(cliMod != null);
        //}

        //[Test]
        //public void Test43()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDNI(40387649, 38333999);
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod != null);
        //}

        //[Test]
        //public void Test44()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDireccion(12345678, "La Rioja", 570);
        //    var cliMod = ClienteMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(cliMod.Calle == "La Rioja" && cliMod.Altura == 570);
        //}

        //[Test]
        //public void Test45()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDireccion(38333999, "La49!oja", 570);
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.Calle == "La49!oja" && cliMod.Altura == 570);
        //}

        //[Test]
        //public void Test46()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateDireccion(38333999, "La Rioja", 570);
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.Calle == "La Rioja" && cliMod.Altura == 570);
        //}

        //[Test]
        //public void Test47()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateFechaNacimiento(38333999, new DateTime(2018, 10, 05));
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.fechaNacimiento == new DateTime(2018, 10, 05));
        //}

        //[Test]
        //public void Test48()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateFechaNacimiento(12345678, new DateTime(2018, 10, 05));
        //    var cliMod = ClienteMG.Instancia.Buscar(12345678);

        //    Assert.IsTrue(cliMod.fechaNacimiento == new DateTime(2018, 10, 05));
        //}

        //[Test]
        //public void Test49()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateFechaNacimiento(38333999, new DateTime(2000, 10, 05));
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.fechaNacimiento == new DateTime(2000, 10, 05));
        //}

        //[Test]
        //public void Test50()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateTelefono(38333999, 123456789);
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.Telefono == 123456789);
        //}

        //[Test]
        //public void Test51()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateTelefono(1234567, 0123456789);
        //    var cliMod = ClienteMG.Instancia.Buscar(1234567);

        //    Assert.IsTrue(cliMod.Telefono == 0123456789);
        //}

        //[Test]
        //public void Test52()
        //{
        //    var modNombres = ClienteMG.Instancia.UpdateTelefono(38333999, 1123456789);
        //    var cliMod = ClienteMG.Instancia.Buscar(38333999);

        //    Assert.IsTrue(cliMod.Telefono == 1123456789);
        //}

        //[Test]
        //public void Test53()
        //{
        //    ClienteMG.Instancia.Delete(12345678);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 0);
        //}
        //[Test]
        //public void Test54()
        //{
        //    ClienteMG.Instancia.Delete(38333999);

        //    Assert.IsTrue(AppDbContext.Instancia.Clientes.Count() == 0);
        //}

        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Deportes

        //[Test]
        //public void Test55()
        //{
        //    DeporteMG.Instancia.Add("Basquet", 8);

        //    Assert.IsTrue(AppDbContext.Instancia.Deportes.Count() == 1);
        //}

        //[Test]
        //public void Test56()
        //{ 
        //    DeporteMG.Instancia.Add("Basquet", 8);

        //    Assert.IsTrue(AppDbContext.Instancia.Deportes.Count() == 1);
        //}

        //[Test]
        //public void Test57()
        //{
        //    DeporteMG.Instancia.Add("Bas17!et", 8);

        //    Assert.IsTrue(AppDbContext.Instancia.Deportes.Count() == 1);
        //}

        //[Test]
        //public void Test58()
        //{
        //    var mod = DeporteMG.Instancia.Update("Golf", "futbol", 10);
        //    var depMod = DeporteMG.Instancia.Buscar("Futbol");

        //    Assert.IsTrue(depMod.Name == "FUTBOL" && depMod.cantJugadores == 10);
        //}

        //[Test]
        //public void Test59()
        //{
        //    var mod = DeporteMG.Instancia.Update("basquet", "fu7b0l", 10);
        //    var depMod = DeporteMG.Instancia.Buscar("fu7b0l");

        //    Assert.IsTrue(depMod.Name == "fu7b0l" && depMod.cantJugadores == 10);
        //}


        //[Test]
        //public void Test60()
        //{
        //    var mod = DeporteMG.Instancia.Update("basquet", "futbol", 10);
        //    var depMod = DeporteMG.Instancia.Buscar("Futbol");

        //    Assert.IsTrue(depMod.Name == "FUTBOL" && depMod.cantJugadores == 10);
        //}

        //[Test]
        //public void Test61()
        //{
        //    DeporteMG.Instancia.Delete("hockey");

        //    Assert.IsTrue(AppDbContext.Instancia.Deportes.Count() == 0);
        //}
        //[Test]
        //public void Test62()
        //{
        //    DeporteMG.Instancia.Delete("futbol");

        //    Assert.IsTrue(AppDbContext.Instancia.Deportes.Count() == 0);
        //}

        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Canchas


        //[Test]
        //public void Test62()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("basquet");

        //    CanchaMG.Instancia.Add(dep, "gonzalez", 13000);


        //    Assert.IsTrue(CanchaMG.Instancia.Listado().Count() == 1);

        //}

        //[Test]
        //public void Test63()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Add(dep, "Avellaneda UNO", 13000);

        //    Assert.IsTrue(CanchaMG.Instancia.Listado().Count() == 2);
        //}

        //[Test]
        //public void Test64()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Add(dep, "Avellaneda UNO", 13000);

        //    Assert.IsTrue(AppDbContext.Instancia.Canchas.Count() == 3);
        //}


        //[Test]
        //public void Test65()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Add(dep, "La73ll3 1", 13000);


        //    Assert.IsTrue(AppDbContext.Instancia.Canchas.Count() == 4);
        //}

        //[Test]
        //public void Test66()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Update("avellaneda uno", dep, "f uno", 13000);

        //    var canchaMOD = CanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(canchaMOD != null);
        //}

        //[Test]
        //public void Test67()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Update("f uno", dep, "f uno", 13000);

        //    var canchaMOD = CanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(canchaMOD != null);
        //}

        //[Test]
        //public void Test68()
        //{
        //    var dep = DeporteMG.Instancia.Buscar("futbol");

        //    CanchaMG.Instancia.Update("gonzalez", dep, "f dos", 13000);

        //    var canchaMOD = CanchaMG.Instancia.Buscar("f dos");

        //    Assert.IsTrue(canchaMOD != null);
        //}

        //[Test]
        //public void Test69()
        //{
        //    CanchaMG.Instancia.Delete("bernabeu");

        //    Assert.IsTrue(AppDbContext.Instancia.Canchas.Count() == 0);
        //}

        //[Test]
        //public void Test70()
        //{
        //    CanchaMG.Instancia.Delete("f uno");

        //    Assert.IsTrue(AppDbContext.Instancia.Canchas.Count() == 0);
        //}

        //[Test]
        //public void Test71()
        //{
        //    CanchaMG.Instancia.Delete("f dos");

        //    Assert.IsTrue(AppDbContext.Instancia.Canchas.Count() == 0);
        //}


        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Elementos

        //[Test]
        //public void Test72()
        //{
        //    ElementoMG.Instancia.Add("pelota f5", 20);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Nombre == "PELOTA F5" && elemento.Stock == 20);

        //}

        //[Test]
        //public void Test73()
        //{
        //    ElementoMG.Instancia.Add("pelota f5", 20);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Nombre == "PELOTA F5" && elemento.Stock == 20);

        //}



        //[Test]
        //public void Test74()
        //{
        //    ElementoMG.Instancia.AddStock("pelota f5", 20);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Stock == 40);

        //}

        //[Test]
        //public void Test75()
        //{
        //    ElementoMG.Instancia.AddStock("pelota basquet", 20);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Nombre == "PELOTA BASQUET" && elemento.Stock == 20);

        //}

        //[Test]
        //public void Test76()
        //{
        //    ElementoMG.Instancia.RestarStock("pelota f5", 5);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Stock == 35);

        //}

        //[Test]
        //public void Test77()
        //{
        //    ElementoMG.Instancia.RestarStock("pelota basquet", 5);

        //    var elemento = ElementoMG.Instancia.Buscar("pelota basquet");

        //    Assert.IsTrue(elemento.Stock == 15);

        //}

        //[Test]
        //public void Test78()
        //{
        //    ElementoMG.Instancia.UpdateNombre("pelota f5", "pelotita");

        //    var elemento = ElementoMG.Instancia.Buscar("pelotita");

        //    Assert.IsTrue(elemento.Nombre == "PELOTITA");

        //}

        //[Test]
        //public void Test79()
        //{
        //    ElementoMG.Instancia.UpdateNombre("pelotita", "pelota f5");

        //    var elemento = ElementoMG.Instancia.Buscar("pelota f5");

        //    Assert.IsTrue(elemento.Nombre == "PELOTA F5");

        //}


        //[Test]
        //public void Test80()
        //{
        //    ElementoMG.Instancia.Delete("pelota basquet");

        //    Assert.IsTrue(ElementoMG.Instancia.Listado().Count() == 0);

        //}

        //[Test]
        //public void Test81()
        //{
        //    ElementoMG.Instancia.Delete("pelota f5");

        //    Assert.IsTrue(ElementoMG.Instancia.Listado().Count() == 0);



        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Elementos Cancha

        //[Test]
        //public void Test82()
        //{
        //    var elemento = ElementoMG.Instancia.Buscar("Pelota f5");
        //    var cancha = CanchaMG.Instancia.Buscar("f uno");

        //    ElementosCanchaMG.Instancia.Add(elemento, cancha, 5);
        //    var elementosAgg = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(elemento.Stock == 10);
        //    Assert.NotNull(elementosAgg);
        //}

        //[Test]
        //public void Test83()
        //{
        //    var elemento = ElementoMG.Instancia.Buscar("Pelota f5");
        //    var cancha = CanchaMG.Instancia.Buscar("f uno");

        //    ElementosCanchaMG.Instancia.Add(elemento, cancha, 20);
        //    var elementosAgg = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(elemento.Stock == 15);
        //    Assert.NotNull(elementosAgg);
        //}

        //[Test]
        //public void Test84()
        //{
        //    var elemento = ElementoMG.Instancia.Buscar("Pelota f5");
        //    var cancha = CanchaMG.Instancia.Buscar("f uno");

        //    ElementosCanchaMG.Instancia.AddCantidad(elemento, cancha, 20);
        //    var elementosAgg = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(elemento.Stock == 15);
        //    Assert.NotNull(elementosAgg);
        //}

        //[Test]
        //public void Test85()
        //{
        //    var elemento = ElementoMG.Instancia.Buscar("Pelota f5");
        //    var cancha = CanchaMG.Instancia.Buscar("f uno");

        //    ElementosCanchaMG.Instancia.AddCantidad(elemento, cancha, 10);
        //    var elementosAgg = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(elemento.Stock == 5);
        //    Assert.IsTrue(elementosAgg.Cantidad == 30);
        //}


        //[Test]
        //public void Test86()
        //{
        //    var elemento = ElementoMG.Instancia.Buscar("Pelota f5");
        //    var cancha = CanchaMG.Instancia.Buscar("f uno");

        //    ElementosCanchaMG.Instancia.RestarCantidad(elemento, cancha, 10);
        //    var elementosAgg = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(elemento.Stock == 15);
        //    Assert.IsTrue(elementosAgg.Cantidad == 20);
        //}

        //[Test]
        //public void Test87()
        //{

        //    ElementosCanchaMG.Instancia.Delete("f tres");

        //    Assert.IsTrue(ElementosCanchaMG.Instancia.Listado().Count() == 0);
        //}

        //[Test]
        //public void Test88()
        //{
        //    ElementosCanchaMG.Instancia.Delete("f uno");
        //    var asig = ElementosCanchaMG.Instancia.Buscar("f uno");

        //    Assert.IsTrue(AppDbContext.Instancia.ElementosCancha.Count() == 0);
        //}


        /// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Turnos

    }
}
   