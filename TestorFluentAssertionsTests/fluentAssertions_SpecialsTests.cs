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

        //dates
    }
}
