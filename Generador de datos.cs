using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SQLServer_Connect{
    class Program{
        private static string[] M          = { "Aaron", "Abel", "Abelardo", "Abraham", "Adalberto", "Adán", "Adolfo", "Adrián", "Adriano", "Agustín", "Alberto", "Alan", "Aldo", "Álbaro", "Alejandro", "Alejo", "Alexis", "Alfredo", "Alonso", "Amadeo", "Amancio", "Angel", "Andrés", "Aníbal", "Antonio", "Antony", "Apolo", "Aquiles", "Aquilino", "Ariel", "Arístides", "Armando", "Arturo", "Augusto", "Aurelio", "Baldomero", "Baltasar", "Barack", "Bartolomé", "Basilio", "Bautista", "Benito", "Benjamín", "Bernardo", "Bonifacio", "Bruno", "Cándido", "Carlos", "Carmelo", "Casimiro", "Cayetano", "Crisanto", "Cristian", "Celso", "César", "Cipriano", "Cirilo", "Claudio", "Conrado", "Constancio", "Constantino", "Cornelio", "Cristóbal", "Dagoberto", "Daniel", "Danilo", "Darío", "David", "Delmiro", "Diego", "Dionisio", "Domingo", "Dominico", "Donato", "Edgar", "Edgardo", "Edith", "Edmundo", "Eduardo", "Edwin", "Efraín", "Elías", "Eloy", "Emilio", "Emanuel", "Emilio", "Encarnación", "Enmanuel", "Enrique", "Erasmo", "Eric", "Ernesto", "Erwin", "Esmerlin", "Esteban", "Euclides", "Eudoxio", "Eufemio", "Eufrasio", "Eugenio", "Eulalio", "Eusebio", "Eustacio", "Evaristo", "Ezequiel", "Fabián", "Faustino", "Fausto", "Federico", "Felix", "Felipe", "Fernando", "Fidel", "Filiberto", "Filomeno", "Flavio", "Florencio", "Florián", "Franco", "Francis", "Francisco", "Franklin", "Fulvio", "Gabriel", "Gustavo", "Leonel", "Leonardo", "Luís", "Javier", "Jefry", "Johansel", "José", "Juan", "Julian", "Julio", "Miguel", "Misael", "Manuel", "Marcos", "Pedro", "Rafael", "Randy", "Samuel" };
        private static string[] F          = { "Abigaíl", "Abril", "Ada", "Adela", "Adelaida", "Adelina", "Adriana", "Ágata", "Aida", "Ainara", "Alejandra", "Alexandra", "Alicia", "Alina", "Amalia", "Amanda", "Amelia", "Amparo", "Ana", "Anastasia", "Andrea", "Angela", "Antonia", "Antonieta", "Araceli", "Asunción", "Aurelia", "Aurora", "Bárbara", "Beatriz", "Belinda", "Berenice", "Bernardina", "Berta", "Bianca", "Bibiana", "Blanca", "Brenda", "Brígida", "Brunilda", "Belkis", "Calixta", "Camelia", "Camila", "Caridad", "Carina", "Carla", "Carmela", "Carmen", "Carol", "Carola", "Carolina", "Casilda", "Catalina", "Cecilia", "Celestina", "Celia", "Cristina", "Cintia", "Clara", "Claudia", "Cleopatra", "Clotilde", "Consuelo", "Cordelia", "Cristal", "Dana", "Débora", "Delia", "Diana", "Dina", "Dolores", "Dominga", "Dora", "Elena", "Eleonor", "Elisa", "Elisabeth", "Elizabeth", "Eloisa", "Elsa", "Elvira", "Emilia", "Ema", "Engracia", "Erica", "Esmeralda", "Esperanza", "Estefanía", "Estela", "Estephany", "Ester", "Eudosia", "Eufemia", "Eufrasia", "Eugenia", "Eulalia", "Eva", "Evangelina", "Fabiola", "Fanny", "Fátima", "Felicia", "Feliciana", "Flavia", "Flora", "Florencia", "Florida", "Florangel", "Francisca", "Frida", "Gabriela", "Johanny", "Josefa", "Josefina", "Juana", "Julia", "Katherine", "Karla", "Luisa", "María", "Melisa", "Miguelina", "Mirelis", "Olga", "Rafaela", "Rosa" };
        private static string[] Apellidos  = {"Almanzar","Almonte","Avila","Aquino","Bueno","Burgos","Cabrera","Cáceres","Calcaño","Ceballos","Collado","Corporan","Cruz","De la Cruz","De los santos","Díaz","Dipre","Duarte","Feliz","Fernandez","Ferrer","Ferrera","Fonseca","García","Gil","Gimenez","Gonzalez","Guerrero","Hernandez","Herrera","León","Lopez","Manzueta","Maracallo","Martinez","Mirabal","Medina","Melo","Mercedes","Mora","Morel","Montás","Nivar","Núñes","Otaño","Ortíz","Paulino","Peña","Perez","Pichardo","Pimentel","Polanco","Valdez","Quezada","Ramos","Roman","Reyez","Reyes","Reyna","Sanchez","Santos","Severino","Solano","Solís","Tejeda","Torres"};
        private static string[] provincias = { "Santo Domingo", "Distrito Nacional", "Santiago", "San Cristóbal", "La Vega", "Puerto Plata", "San Pedro de Macorís", "Duarte", "La Altagracia", "La Romana", "San Juan", "Espaillat", "Azua", "Barahona", "Monte Plata", "Peravia", "Monseñor Nouel", "Valverde", "Sánchez Ramírez", "María Trinidad Sánchez", "Monte Cristi", "Samaná", "Bahoruco", "Hermanas Mirabal", "El Seibo (o El Seybo)", "Hato Mayor", "Dajabón", "Elías Piña", "San José de Ocoa", "Santiago Rodríguez", "Independencia", "Pedernales" };
        private static string[] paises     = { "Afganistan", "Africa del Sur", "Albania", "Alemania", "Andorra", "Angola", "Antigua y Barbuda", "Antillas Holandesas", "Arabia Saudita", "Argelia", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarusia", "Belgica", "Belice", "Benin", "Bermudas", "Bolivia", "Bosnia", "Botswana", "Brasil", "Brunei Darussulam", "Bulgaria", "Burkina Faso", "Burundi", "Butan", "Camboya", "Camerun", "Canada", "Cape Verde", "Chad", "Chile", "China", "Chipre", "Colombia", "Comoros", "Congo", "Corea del Norte", "Corea del Sur", "Costa de Marfíl", "Costa Rica", "Croasia", "Cuba", "Dinamarca", "Djibouti", "Dominica", "Ecuador", "Egipto", "El Salvador", "Emiratos Arabes Unidos", "Eritrea", "Eslovenia", "España", "Estados Unidos", "Estonia", "Etiopia", "Fiji", "Filipinas", "Finlandia", "Francia", "Gabon", "Gambia", "Georgia", "Ghana", "Granada", "Grecia", "Groenlandia", "Guadalupe", "Guam", "Guatemala", "Guayana Francesa", "Guerney", "Guinea", "Guinea-Bissau", "Guinea Equatorial", "Guyana", "Haiti", "Holanda", "Honduras", "Hong Kong", "Hungria", "India", "Indonesia", "Irak", "Iran", "Irlanda", "Islandia", "Islas Caiman", "Islas Faroe", "Islas Malvinas", "Islas Marshall", "Islas Solomon", "Islas Virgenes Britanicas", "Islas Virgenes (U.S.)", "Israel", "Italia", "Jamaica", "Japon", "Jersey", "JJordania", "Kazakhstan", "Kenia", "Kiribati", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lesotho", "Libano", "Liberia", "Libia", "Liechtenstein", "Lituania", "Luxemburgo", "Macao", "Macedonia", "Madagascar", "Malasia", "Malawi", "Maldivas", "Mali", "Malta", "Marruecos", "Martinica", "Mauricio", "Mauritania", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Mozambique", "Myanmar (Burma)", "Namibia", "Nepal", "Nicaragua", "Niger", "Nigeria", "Noruega", "Nueva Caledonia", "Nueva Zealandia", "Oman", "Pakistan", "Palestina", "Panama", "Papua Nueva Guinea", "Paraguay", "Peru", "Polinesia Francesa", "Polonia", "Portugal", "Puerto Rico", "Qatar", "Reino Unido", "Republica Centroafricana", "Republica Checa", "Republica Democratica del Congo", "Republica Dominicana", "Republica Eslovaca", "Reunion", "Ruanda", "Rumania", "Rusia", "Sahara", "Samoa", "San Cristobal-Nevis (St. Kitts)", "San Marino", "San Vincente y las Granadinas", "Santa Helena", "Santa Lucia", "Santa Sede (Vaticano)", "Sao Tome & Principe", "Senegal", "Seychelles", "Sierra Leona", "Singapur", "Siria", "Somalia", "Sri Lanka (Ceilan)", "Sudan", "Sudan del Sur", "Suecia", "Suiza", "Sur Africa", "Surinam", "Swaziland", "Tailandia", "Taiwan", "Tajikistan", "Tanzania", "Timor Oriental", "Togo", "Tokelau", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkmenistan", "Turquia", "Ucrania", "Uganda", "Union Europea", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe", };
        private static Random r = new Random();

        private static string GetName(char sexo) {
            string nombre;

            if (sexo == 'm')
                nombre = M[r.Next(M.Length)] + " " + M[r.Next(M.Length)];
            else
                nombre = F[r.Next(F.Length)] + " " + F[r.Next(F.Length)];
            
            return nombre;
        }


        private static string GetLastName() {
            return Apellidos[r.Next(Apellidos.Length)] + " " + Apellidos[r.Next(Apellidos.Length)];
        }


        static void Main(string[] args){
            try{
                string nombre,
                       apellido,
                       server,
                       dbName;
                
                int edad,
                    cantidadRegistros;
                
                char sexo;

                Console.Write("Introduzca el nombre del servidor: ");
                server = Console.ReadLine();

                Console.Write("Nombre de la base de datos: ");
                dbName = Console.ReadLine();

                server             = (server.Length > 0) ? server : "TESTSERVER";
                dbName             = (dbName.Length > 0) ? dbName : "prueba";
                cantidadRegistros  = 2000;


                SqlConnection connection = new SqlConnection(@"Data Source="+server+";Initial Catalog="+dbName+";Integrated Security=True");
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.Connection.Open();

                Console.Write("Desea crear la tabla?(S/N): ");
                            if (Console.ReadLine().ToLower() == "s"){
                                cmd.CommandText = "IF OBJECT_ID('dbo.personas', 'U') IS NOT NULL DROP TABLE personas;" +
                                                  "CREATE TABLE personas(" +
                                                      "id_persona int identity not null," +
                                                      "nombre varchar(30) not null," +
                                                      "apellido varchar(30) not null," +
                                                      "edad int not null," +
                                                      "sexo varchar(1) not null)";
                                cmd.ExecuteNonQuery();
                            }
                


                Console.WriteLine("Insertando datos en '" + dbName + "'.");

                for (int i = 0; i < cantidadRegistros; i++){
                    sexo      = (r.Next(10) >= 5)? 'm':'f';
                    edad      = r.Next(12, 85);
                    

                    nombre    = GetName(sexo);
                    apellido  = GetLastName();

                    cmd.CommandText = "INSERT INTO personas(nombre, apellido, edad, sexo) VALUES('"+nombre+"','"+apellido+"',"+edad+",'"+sexo+"');";
                    //cmd.CommandText = "INSERT INTO provincias(nombre) values('"+provincias[i]+"')";
                    cmd.ExecuteNonQuery();
                }

                cmd.Connection.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Completo");
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
