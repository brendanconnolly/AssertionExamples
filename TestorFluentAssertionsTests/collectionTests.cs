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

    public class collectionTests
    {

        [Test]
        public void listEmpty_test()
        {
            var player1 = new Player("Joe Tester");
            var teamMember1 = new TestorTheBarbarian();

            //uncomment line below to fail test
            //player1.Party.Add(teamMember1);

            //Nunit classic model
            CollectionAssert.IsEmpty(player1.Party);
            //--> Expected: <empty> But was: < <TestorTheBarbarianDemo.TestorTheBarbarian > > 

            //NUnit Constraint model
            Assert.That(player1.Party, Is.Empty);
            //--> Expected: <empty> But was: < <TestorTheBarbarianDemo.TestorTheBarbarian > > 

            //FluentAssertions syntax
            player1.Party.Should().BeEmpty();
            //-->Result Message: Expected collection to be empty, but found {
            //    TestorTheBarbarianDemo.TestorTheBarbarian
            //{
            //        ActiveWeapon = < null >
            //        Attacks = { "Clobber"}
            //        BattleCry = ""
            //        Health = 100
            //        Name = "Testor The Mighty Barbarian"
            //        Weapons = { "Fists Of Fury"}
            //    }
            // }.
        }

        [Test]
        public void listContains_test()
        {
            var player1 = new Player("Joe Tester");
            var teamMember1 = new TestorTheBarbarian();
            var teamMember2 = new MasterCodo();

            player1.Party.Add(teamMember2);
            //comment line below to fail test
            player1.Party.Add(teamMember1);


            //Nunit classic model
            CollectionAssert.Contains(player1.Party, teamMember1);
            //--> Expected: collection containing <TestorTheBarbarianDemo.TestorTheBarbarian> But was: < <TestorTheBarbarianDemo.MasterCodo > > 

            //NUnit Constraint model
            Assert.That(player1.Party, Has.Member(teamMember1));
            //--> Expected: collection containing <TestorTheBarbarianDemo.TestorTheBarbarian> But was: < <TestorTheBarbarianDemo.MasterCodo > > 

            //FluentAssertions syntax
            player1.Party.Should().Contain(teamMember1);
            //-->Result Message: Expected collection {
            //                TestorTheBarbarianDemo.MasterCodo
            //            {
            //                ActiveWeapon = < null >
            //                Attacks = { "Sling"}
            //                BattleCry = ""
            //                Health = 100
            //                Name = "Master Codo"
            //                Weapons = { "Fiery Fingers"}
            //                }
            //            }
            //            to contain

            //                TestorTheBarbarianDemo.TestorTheBarbarian
            //            {
            //                ActiveWeapon = < null >
            //                Attacks = { "Clobber"}
            //                BattleCry = ""
            //                Health = 100
            //                Name = "Testor The Mighty Barbarian"
            //                Weapons = { "Fists Of Fury"}
            //            }.
        }

        [Test]
        public void listContains_predicate_test()
        {
            var player1 = new Player("Joe Tester");
            var teamMember1 = new TestorTheBarbarian();
            var teamMember2 = new MasterCodo();

            //comment line below to fail test
            player1.Party.Add(teamMember1);
            player1.Party.Add(teamMember2);

            //Nunit does not have an equivalent either separate asserts or a boolean which 
            // will loose detail and have a generic message 
            //Assert.That(player1.Party.Any(p => p.Name == "Testor The Mighty Barbarian"), Is.True);
            //--> Expected: True But was: False

            //FluentAssertions syntax
            player1.Party.Should().Contain(p => p.Name == "Testor The Mighty Barbarian");
            //-->Result Message: Collection {
            //    TestorTheBarbarianDemo.MasterCodo
            //    {
            //        ActiveWeapon = < null >
            //        Attacks = { "Sling"}
            //        BattleCry = ""
            //        Health = 100
            //        Name = "Master Codo"
            //        Weapons = { "Fiery Fingers"}
            //    }
            //   }
            //   should have an item matching(p.Name == "Testor The Mighty Barbarian").

        }

        [Test]
        public void listAll_test()
        {
            var player1 = new Player("Joe Tester");
            var teamMember1 = new TestorTheBarbarian();
            var teamMember2 = new MasterCodo();

            player1.Party.Add(teamMember1);
            player1.Party.Add(teamMember2);
            //to fail test
            //teamMember2.Health = 0;

            //Nunit does not have an equivalent either separate asserts or a boolean which 
            // will loose detail and have a generic message 
            Assert.That(player1.Party.All(p => p.Health > 0), Is.True);

            //FluentAssertions syntax
            player1.Party.Should().OnlyContain(p => p.Health > 0);
            //-->Result Message: Expected collection to contain only items matching(p.Health > 0), but {
            //     TestorTheBarbarianDemo.MasterCodo
            //    {
           //         ActiveWeapon = < null >
           //         Attacks = { "Sling"}
           //         BattleCry = ""
           //         Health = 0
           //         Name = "Master Codo"
           //         Weapons = { "Fiery Fingers"}
           //     }
           //    }
           //    do (es)not match.
        }
    }
}
