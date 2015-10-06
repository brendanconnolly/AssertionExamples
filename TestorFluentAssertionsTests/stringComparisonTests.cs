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

            //FluentAssertions syntax
            testor.Name.Should().Be(expectedName);
            //--> Result Message: Expected string to be "testor the mighty barbarian", but 
            //     "Testor The Mighty Barbarian" differs near "Tes"(index 0).

            //with optional description
            testor.Name.Should().Be(expectedName, because: "this is case sensitive");
            //--> Result Message: Expected string to be "testor the mighty barbarian" because this is case sensitive, but
            //      "Testor The Mighty Barbarian" differs near "Tes"(index 0).
        }

        [Test]
        public void stringComparison_ignoreCase_Test()
        {
            var testor = new TestorTheBarbarian();
            //Nunit Classic Model
            var expectedName = "testor the mighty barbarian";

            //to fail test
             //expectedName = "testor";

            StringAssert.AreEqualIgnoringCase(expectedName, testor.Name);
            //-->Expected: "testor", ignoring case But was: "Testor The Mighty Barbarian"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.EqualTo(expectedName).IgnoreCase);
            //-->Expected: "testor", ignoring case But was: "Testor The Mighty Barbarian"

            //FluentAssertions syntax
            testor.Name.Should().BeEquivalentTo(expectedName);
            //--> Result Message: Expected string to be equivalent to "testor" with a length of 6, but 
            //    "Testor The Mighty Barbarian" has a length of 27.

            //with optional description
            testor.Name.Should().BeEquivalentTo(expectedName, because: "we're ignoring case");
            //--> Result Message: Expected string to be equivalent to "testor" with a length of 6 because we're ignoring case, but 
            //    "Testor The Mighty Barbarian" has a length of 27.
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

            //FluentAssertions syntax
             testor.Name.Should().Contain(expectedText);
            //--> Result Message:	Expected string "Testor The Mighty Barbarian" to contain "Conan".

            //optional desctiption
            testor.Name.Should().Contain(expectedText,because:"we are looking to rent the movie");
            //--> Result Message:	Expected string "Testor The Mighty Barbarian" to contain "Conan" because we are looking to rent the movie.
        }

        [Test]
        public void stringDoesNotContain_Test()
        {
            var testor = new TestorTheBarbarian();

            // to fail test comment above and uncomment below
            //var testor = new Enemy() { Name = "Bugra" };

            //Nunit Classic Model
            StringAssert.DoesNotContain("Bugra", testor.Name);
            // --> Expected: not String containing "Bugra" But was:  "Bugra"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringContaining("Bugra"));
            // --> Expected: not String containing "Bugra" But was:  "Bugra"

            //FluentAssertions syntax
            testor.Name.Should().NotContain("Bugra");
            // --> Result Message:	Did not expect string "Bugra" to contain "Bugra".

            //optional description
            testor.Name.Should().NotContain("Bugra",because: "its name is Testor");
            // --> Result Message:	Did not expect string "Bugra" to contain "Bugra" because its name is Testor.
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

            //FluentAssertions syntax
            testor.Name.Should().StartWith(expectedText);
            //--> Result Message: Expected string to start with "Conan", but "Testor The Mighty Barbarian" differs near "Tes"(index 0).

            //with optional description
            testor.Name.Should().StartWith(expectedText,because:"we're looking to rent the movie");
            //--> Result Message: Expected string to start with "Conan" because we're looking to rent the movie, but 
            //                 "Testor The Mighty Barbarian" differs near "Tes"(index 0).
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

            //FluentAssertions syntax
            testor.Name.Should().EndWith(expectedText);
            //--> Result Message:	Expected string "Testor The Mighty Barbarian" to end with "Gentle".

            //with optional description
            testor.Name.Should().EndWith(expectedText, because: "appearances can be deceiving");
            //--> Result Message:	Expected string "Testor The Mighty Barbarian" to end with "Gentle" because appearances can be deceiving.
        }

        [Test]
        public void stringNotStartWith_Test()
        {
            var testor = new TestorTheBarbarian();

            //comment above and uncomment below to fail test
            //var testor = new Enemy() { Name = "Bugra" };

            //Nunit Classic Model
            StringAssert.DoesNotStartWith("Bug", testor.Name);
            // --> Expected: not String starting with "Bug" But was:  "Bugra"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringStarting("Bug"));
            // --> Expected: not String starting with "Bug" But was:  "Bugra"

            //FluentAssertions syntax
            testor.Name.Should().NotStartWith("Bug");
            // --> Result Message:	Expected string that does not start with "Bug", but found "Bugra".

            //with optional description
             testor.Name.Should().NotStartWith("Bug", because:"testor isn't Bugra");
            // --> Result Message:	Expected string that does not start with "Bug" because testor isn't Bugra, but found "Bugra".
        }

        [Test]
        public void stringNotEndWith_Test()
        {
            var testor = new TestorTheBarbarian();
            
            //comment above and uncomment below to fail test
            //var testor = new Enemy() { Name = "Bugra" };

            //Nunit Classic Model
            StringAssert.DoesNotEndWith("ra", testor.Name);
            // -->Expected: not String ending with "do" But was:  "Master Codo"

            //NUnit Constraint model
            Assert.That(testor.Name, Is.Not.StringEnding("ra"));
            // -->Expected: not String ending with "do" But was:  "Master Codo"

            //FluentAssertions syntax
            testor.Name.Should().NotEndWith("ra");
            // --> Result Message:	Expected string "Bugra" not to end with "ra".

            testor.Name.Should().NotEndWith("do", because:"object is a testor");
            // --> Result Message:	Expected string "Bugra" not to end with "ra" because object is a testor.
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

            //FluentAssertions syntax
            testor.ActiveWeapon.Should().NotBeNullOrEmpty();
            // --> Result Message:	Expected string not to be <null> or empty, but found <null>.

            //with optional description
            testor.ActiveWeapon.Should().NotBeNullOrEmpty(because:"weapon has been equipped");
            // --> Result Message:	Expected string not to be <null> or empty because weapon has been equipped, but found <null>.
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

            //FluentAssertions syntax
            testor.ActiveWeapon.Should().BeNullOrEmpty();
            // --> Result Message:	Expected string to be <null> or empty, but found "Fists of Fury".
            
            // with optional description
            testor.ActiveWeapon.Should().BeNullOrEmpty(because:"no weapon has been equipped");
            // --> Result Message:	Expected string to be <null> or empty because no weapon has been equipped, but found "Fists of Fury".


        }


    }
}
