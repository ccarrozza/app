using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace app
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection,int decay_rate)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);

            using(connection)
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return first + second;
        }

        void ensure_all_are_positive(params int[] numbers)
        {
            if (numbers.All(x => x > 0)) return;
            throw new ArgumentException("Can't deal with negatives");
        }

        public void shut_off()
        {
            if (Thread.CurrentPrincipal.IsInRole("dsfsdf")) return;

            throw new SecurityException();
        }
    }
}