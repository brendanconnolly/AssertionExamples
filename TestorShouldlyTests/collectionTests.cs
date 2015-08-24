using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestorTheBarbarianDemo;
using Shouldly;

namespace TestorShouldlyTests
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

            //shouldly syntax
            player1.Party.ShouldBeEmpty();
            //-->player1.Party should be empty but had 1 item and it was [TestorTheBarbarianDemo.TestorTheBarbarian]
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

            //shouldly syntax
            player1.Party.ShouldContain(teamMember1);
            //-->player1.Party should contain TestorTheBarbarianDemo.TestorTheBarbarian but does not
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
            Assert.That(player1.Party.Any(p => p.Name == "Testor The Mighty Barbarian"), Is.True);
            //--> Expected: True But was: False

            //shouldly syntax
            player1.Party.ShouldContain(p=>p.Name=="Testor The Mighty Barbarian");
            //-->player1.Party should contain an element satisfying the condition (p.Name=="Testor The Mighty Barbarian") 
            // but does not
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
            
            //shouldly syntax
            player1.Party.ShouldAllBe(p=>p.Health >0);
            //-->player1.Party should satisfy the condition (p.Health>0) but
            // [TestorTheBarbarianDemo.MasterCodo] but do not
        }
    }
}
