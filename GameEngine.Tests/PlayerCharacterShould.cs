using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        private PlayerCharacter playerCharacter;

        public static IEnumerable<object[]> Damages => new List<object[]>
        {
            new object[] {1, 99},
            new object[] {0, 100},
            new object[] {100, 1},
            new object[] {101, 1},
            new object[] {50, 50},
            new object[] {40, 60}
        };

        [TestInitialize]
        public void TestInit()
        {
            playerCharacter = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };
        }

        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
            {
                new object[] {1, 99},
                new object[] {0, 100},
                new object[] {100, 1},
                new object[] {101, 1},
                new object[] {50, 50},
                new object[] {10, 90}
            };
        }

        [TestMethod]
        public void NoobPropertyTrueOnCreation_ReturnsTrue()
        {
            Assert.IsTrue(playerCharacter.IsNoob);
            //Assert.IsFalse(player.IsNoob);
        }

        [TestMethod]
        public void NotHaveNickNameByDefault_ReturnsNullEmptyString()
        {
            Assert.IsNull(playerCharacter.Nickname);
            //Assert.IsNotNull(player.Nickname);
        }

        [TestMethod]
        [PlayerDefaults]
        public void Have100HealthDefault()
        {
            Assert.AreEqual(100, playerCharacter.Health);
            //Assert.IsNotNull(player.Nickname);
        }

        [DataTestMethod]
        //[DynamicData(nameof(Damages))]
        //[DynamicData(nameof(GetDamages), DynamicDataSourceType.Method)]
        //[DynamicData(nameof(DamageData.GetDamages), 
        //             typeof(DamageData), 
        //             DynamicDataSourceType.Method)]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData),
            typeof(ExternalHealthDamageTestData))]
        //[DataRow(1, 99)]
        //[DataRow(0, 100)]
        //[DataRow(100, 1)]
        //[DataRow(101, 1)]
        //[DataRow(50, 50)]
        //[TestCategory("Player Health")]
        [PlayerHealth]
        [CsvDataSource("Damage.csv")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            playerCharacter.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, playerCharacter.Health);
            //Assert.IsNotNull(player.Nickname);
        }

        [TestMethod]
        public void TakeDamage_NotEqual()
        {
            playerCharacter.TakeDamage(99);

            Assert.AreNotEqual(99, playerCharacter.Health);
        }

        [TestMethod]
        public void IncreaseHealthAfterSleeping()
        {
            playerCharacter.Sleep();

            //Assert.IsTrue(playerCharacter.Health >= 101 && playerCharacter.Health <= 200);
            Assert.That.IsInRange(playerCharacter.Health,101,200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
          
            Assert.AreEqual("SARAH SMITH", playerCharacter.FullName, true);
        }

        [TestMethod]
        public void StartsWithFirstName()
        {
          

            StringAssert.StartsWith(playerCharacter.FullName, "Sarah");
        }

        [TestMethod]
        public void StartsWithLastName()
        {
          

            StringAssert.EndsWith(playerCharacter.FullName, "Smith");
        }

        [TestMethod]
        public void ContainsWithinFullName()
        {
          

            StringAssert.Contains(playerCharacter.FullName, "ah Sm");
        }

        [TestMethod]
        public void CalculateTitleCaseWithinFullName()
        {
           

            StringAssert.Contains(playerCharacter.FullName, "ah Sm");
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(playerCharacter.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NoStaffOfWonder()
        {
         

            CollectionAssert.DoesNotContain(playerCharacter.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
         

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expectedWeapons, playerCharacter.Weapons);
        }

        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
        

            var expectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            CollectionAssert.AreEquivalent(expectedWeapons, playerCharacter.Weapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
         

            CollectionAssert.AllItemsAreUnique(playerCharacter.Weapons);
        }

        [TestMethod]
        public void AtLeastOneSword()
        {
         

            //Assert.IsTrue(playerCharacter.Weapons.Any(w => w.Contains("Sword")));
            CollectionAssert.That.AtLeastOneItemSatisfies(playerCharacter.Weapons,weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void NoWeapons()
        {

            //Assert.IsFalse(playerCharacter.Weapons.Any(w => string.IsNullOrWhiteSpace("Sword")));
           //CollectionAssert.That.AllItemsNotNullOrWhitespace(playerCharacter.Weapons);
           CollectionAssert.That.AllItemsSatisfy(playerCharacter.Weapons,weapon => !string.IsNullOrWhiteSpace(weapon));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));

            //CollectionAssert.That.AllItemsNotNullOrWhitespace(sut.Weapons);

            //sut.Weapons.Add(" ");

            //CollectionAssert.That.AllItemsSatisfy(sut.Weapons,
            //      weapon => !string.IsNullOrWhiteSpace(weapon));

            CollectionAssert.That.All(playerCharacter.Weapons, weapon =>
            {
                StringAssert.That.NotNullOrWhiteSpace(weapon);
                Assert.IsTrue(weapon.Length > 5);
                //etc.
            });
        }


    }
}