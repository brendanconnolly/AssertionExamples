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
   public class stringComparisonTests
    {
        [Test]
        public void stringComparison_Test()
        {
            var testor = new TestorTheBarbarian();
            var expectedName = "Testor The Mighty Barbarian";

            //to fail test
            //expectedName = "testor the mighty barbarian";

            //Nunit classic model
            Assert.AreEqual(expectedName, testor.Name);
            //-->Expected: "testor the mighty barbarian" But was: "Testor The Mighty Barbarian"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.EqualTo(expectedName));
            //-->Expected: "testor the mighty barbarian" But was: "Testor The Mighty Barbarian"

            //shouldly syntax
            testor.Name.ShouldBe(expectedName);
            //-->testor.Name should be "testor the mighty barbarian" but was "Testor The Mighty Barbarian"
        }

        [Test]
        public void stringComparison_ignoreCase_Test()
        {
            var testor = new TestorTheBarbarian();
            //Nunit Classic Model
            var expectedName = "testor the mighty barbarian";
            
            //to fail test
            // expectedName = "testor";

            StringAssert.AreEqualIgnoringCase(expectedName, testor.Name);
            //-->Expected: "testor", ignoring case But was: "Testor The Mighty Barbarian"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.EqualTo(expectedName).IgnoreCase);
            //-->Expected: "testor", ignoring case But was: "Testor The Mighty Barbarian"

            //shouldly syntax
            testor.Name.ShouldBe(expectedName, Case.Insensitive);
            //-->testor.Name should be "testor", but was: "Testor The Mighty Barbarian"
        }

        [Test]
        public void stringContains_Test()
        {
            var testor = new TestorTheBarbarian();
            var expectedText = "Testor";
            //to fail test
            //expectedText = "Conan";

            //Nunit Classic Model
            StringAssert.Contains(expectedText, testor.Name);
            //-->Expected: String Containing "Conan" But was: "Testor The Mighty Barbarian"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.StringContaining(expectedText));
            //-->Expected: String Containing "Conan" But was: "Testor The Mighty Barbarian"

            //shouldly syntax
            testor.Name.ShouldContain(expectedText);
            //--> testor.Name should contain "Conan" but does not
        }

        [Test]
        public void stringDoesNotContain_Test()
        {
            var testor = new TestorTheBarbarian();

            //Nunit Classic Model
            StringAssert.DoesNotContain("Bugra", testor.Name);

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringContaining("Bugra"));

            //shouldly syntax
            testor.Name.ShouldNotContain("Bugra");
        }

        [Test]
        public void stringStartWith_Test()
        {
            var testor = new TestorTheBarbarian();

            var expectedText = "Testor";
            //to fail test
            //expectedText = "Conan";

            //Nunit Classic Model
            StringAssert.StartsWith(expectedText, testor.Name);
            //--> Expected: String starting with "Conan" But was: "Testor The Mighty Barbarian"
            
            //NUnit Constraint model
            Assert.That(testor.Name, Is.StringStarting(expectedText));
            //--> Expected: String starting with "Conan" But was: "Testor The Mighty Barbarian"
            
            //shouldly syntax
            testor.Name.ShouldStartWith(expectedText);
            //--> testor.Name should start with "Conan" but was "Testor The Mighty Barbarian"
        }

        [Test]
        public void stringEndWith_Test()
        {
            var testor = new TestorTheBarbarian();
            var expectedText = "Barbarian";
            //to fail test
            //expectedText = "Gentle";

            //Nunit Classic Model
            StringAssert.EndsWith(expectedText, testor.Name);
            //--> Expected: String ending with "Gentle" But was: "Testor The Mighty Barbarian"
            
            //NUnit Constraint model
            Assert.That(testor.Name, Is.StringEnding(expectedText));
            //--> Expected: String ending with "Gentle" But was: "Testor The Mighty Barbarian"

            //shouldly syntax
            testor.Name.ShouldEndWith(expectedText);
            //--> testor.Name should end with "Gentle" but was "Testor The Mighty Barbarian"
        }

        [Test]
        public void stringNotStartWith_Test()
        {
            var testor = new TestorTheBarbarian();

            //Nunit Classic Model
            StringAssert.DoesNotStartWith("Bug", testor.Name);

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringStarting("Bug"));

            //shouldly syntax
            testor.Name.ShouldNotStartWith("Bug");
        }

        [Test]
        public void stringNotEndWith_Test()
        {
            var testor = new TestorTheBarbarian();

            //Nunit Classic Model
            StringAssert.DoesNotEndWith("ra", testor.Name);

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringEnding("ra"));

            //shouldly syntax
            testor.Name.ShouldNotEndWith("ra");
        }

        [Test]
        public void stringNotNullOrEmpty_Test()
        {
            var testor = new TestorTheBarbarian();
            //comment line below to fail test
            testor.EquipWeapon("Fists of Fury");

            //Nunit Classic Model
            Assert.IsNotNullOrEmpty(testor.ActiveWeapon);
            // --> Expected: not null or empty string   But was: null

            //NUnit Constraint model
            Assert.That(testor.ActiveWeapon, Is.Not.Null.Or.Empty);
            // --> Expected: not null or empty string   But was: null

            //shouldly syntax
            testor.ActiveWeapon.ShouldNotBeNullOrEmpty();
            // --> testor.ActiveWeapon should not be null or empty
        }

        [Test]
        public void stringNullOrEmpty_Test()
        {
            var testor = new TestorTheBarbarian();
            //to fail test
            //testor.EquipWeapon("Fists of Fury");
            
            //Nunit Classic Model
            Assert.IsNullOrEmpty(testor.ActiveWeapon);
            // --> Expected: null or empty string   But was: "Fists of Fury"

            //NUnit Constraint model
            Assert.That(testor.ActiveWeapon, Is.Null.Or.Empty);
            // --> Expected: null or empty string   But was: "Fists of Fury"

            //shouldly syntax
            testor.ActiveWeapon.ShouldBeNullOrEmpty();
            // --> testor.ActiveWeapon should be null or empty
        }


    }
}
