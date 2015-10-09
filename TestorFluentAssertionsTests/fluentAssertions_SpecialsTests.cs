using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestorTheBarbarianDemo;
using FluentAssertions;

namespace TestorFluentAssertionsTests
{
    class fluentAssertionsSpecialsTests
    {
        [Test]
        public void objectGraph_EquivalentTo_test()
        {
            var player1 = new Player("Joe Tester");
            var p1_teamMember1 = new TestorTheBarbarian() { Health = 99 };
            var p1_teamMember2 = new MasterCodo() { Health = 100 };

            player1.Party.Add(p1_teamMember1);
            player1.Party.Add(p1_teamMember2);

            var player2 = new Player("Joe Tester");
            var p2_teamMember1 = new TestorTheBarbarian() { Health = 99 };
            var p2_teamMember2 = new MasterCodo() { Health = 100 };

            player2.Party.Add(p2_teamMember1);
            player2.Party.Add(p2_teamMember2);

            //to fail test uncomment
            //p1_teamMember2.Health = 0; 
            //p2_teamMember1.AddAttack("Bug Be Gone");
            //Nunit does not have an equivalent would need separate asserts 

            //FluentAssertions syntax
            player1.ShouldBeEquivalentTo(player2);
            // --> Result Message:	
            //            Expected member Party[0].Attacks to be a collection with 2 item(s), but found 1.
            //            Expected member Party[1].Health to be 100, but found 0.
            //            With configuration:
            //             - Use declared types and members
            //             - Compare enums by value
            //             - Match member by name(or throw)
            //             - Be strict about the order of items in byte arrays
        }

        [Test]
        public void typeValidation_Test()
        {
            iCharacter testor = new TestorTheBarbarian();

            //to fail test
            //testor = new MasterCodo();

            //Nunit classic model
            Assert.IsInstanceOf<TestorTheBarbarian>(testor);
            //--> Result Message:	Expected: instance of < TestorTheBarbarianDemo.TestorTheBarbarian >
            //       But was:  < TestorTheBarbarianDemo.MasterCodo >

            //NUnit Constraint model
            Assert.That(testor, Is.InstanceOf<TestorTheBarbarian>());
            //--> Result Message:	Expected: instance of < TestorTheBarbarianDemo.TestorTheBarbarian >
            //       But was:  < TestorTheBarbarianDemo.MasterCodo >

            //FluentAssertions syntax
            testor.Should().BeOfType<TestorTheBarbarian>();
            //-->Result Message:	Expected type to be TestorTheBarbarianDemo.TestorTheBarbarian, 
            //      but found TestorTheBarbarianDemo.MasterCodo.
        }

        [Test]
        public void timedResult_Test()
        {
            var testor = new TestorTheBarbarian();
            //set sleep to >1000 to fail test
            const int sleepyTime = 500;

            //nunit closest option MaxTime attribute on the test method. 
            testor.ExecutionTimeOf(z => z.Rest(sleepyTime)).ShouldNotExceed(1.Seconds());

            //-->Execution of (z.Rest(1500)) should not exceed 1s, but it required 1.698s

        }
        //dates
    }
}
