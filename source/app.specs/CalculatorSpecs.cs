using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    public class CalculatorSpecs
    {
        public class concern : Observes<Calculator>
        {
        }

        public class when_created : concern
        {
            Establish c = () =>
                connection = depends.on<IDbConnection>();

            It should_not_open_the_db_connection = () =>
                connection.never_received(x => x.Open());

            static IDbConnection connection;
        }

        public class when_adding_two_numbers : concern
        {
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
                command = fake.an<IDbCommand>();

                sut_factory.create_using(() => new Calculator(connection, 2));

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 3);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_command = () =>
                command.received(x => x.ExecuteNonQuery());

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            It should_dispose_of_the_necessary_items = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        public class when_shutting_off_the_calculator : concern
        {
            Establish c = () =>
            {
                principal = fake.an<IPrincipal>();

                spec.change(() => Thread.CurrentPrincipal).to(principal);
            };


            public class and_they_are_in_the_correct_role : when_shutting_off_the_calculator
            {
                Establish c = () =>
                    principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                Because b = () =>
                    sut.shut_off();

                It should_not_throw_an_exception = () =>
                {

                };
            }

            public class and_they_are_not_In_the_correct_role : when_shutting_off_the_calculator
            {
                Establish c = () =>
                    principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                Because b = () =>
                    spec.catch_exception(() => sut.shut_off());


                It should_throw_a_security_exception = () =>
                    spec.exception_thrown.ShouldBeAn<SecurityException>();
            }


            static IPrincipal principal;
        }

        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                spec.catch_exception(() => sut.add(2, -3));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();
        }
    }
}