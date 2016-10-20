using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroControleFinanceiro.Domain.Models;
using MacroControleFinanceiro.Domain.Contracts.Repositories;
using MacroControleFinanceiro.Infra.Repositories;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.Unity;
using MacroControleFinanceiro.Startup;
using MacroControleFinanceiro.Domain.Contracts.Services;

namespace MacroControleFinanceiro.ConsoleTest
{
    public class Program
    {
        public static void Main()
        {
            //Segundo teste
            //var user = new User("Marcel","marcel@marcel.com");

            //try
            //{
            //    user.SetPassword("12345686ma", "12345686ma");
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}

            //user.Validate();
            //Console.WriteLine(user.Name);
            //Console.WriteLine(user.Email);
            //Console.WriteLine(user.Id);
            //Console.WriteLine(user.Password);
            //Console.ReadLine();

            //Segundo teste
            //var user = new User("Marcel", "marcel@marcel.com");
            //try
            //{
            //    user.SetPassword("12345686ma", "12345686ma");
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}

            //user.Validate();

            //using (IUserRepository userRep = new UserRepository())
            //{
            //    userRep.Create(user);
            //}
            //using (IUserRepository userRep = new UserRepository())
            //{
            //    User retorno = userRep.Get("marcel@marcel.com");
            //    Console.WriteLine(retorno.Name);
            //}

            //Terceiro Teste
            //Idioma
            var ci = new CultureInfo("U");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IUserService>();

            try
            {
                service.Register("", "marcel2@gmail.com", "123456789", "123456789");
                Console.WriteLine("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                service.Dispose();
            }


            Console.ReadLine();


        }
    }
}
