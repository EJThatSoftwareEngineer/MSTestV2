using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{   
    [TestClass]
    [TestCategory(TestCategories.NORMAL_ENEMY_CREATION)]
    [TestCategory(TestCategories.BOSS_ENEMY_CREATION)]
    //[Ignore]
    public class EnemyFactoryShould
    {

        [TestMethod]
        public void NotAllowNullName()
        {

            Console.WriteLine("Calling NotAllowNullName");

            var sut = new EnemyFactory();

            Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));

        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var sut = new EnemyFactory();

            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>(
                () => sut.Create("Zombie", true));

            Assert.AreEqual("Zombie",ex.RequestedEnemyName);


        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            var sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsInstanceOfType(enemy,typeof(NormalEnemy));
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault_NotSameInstance()
        {
            var sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotInstanceOfType(enemy,typeof(BossEnemy));
        }

        
        [TestMethod]
        public void CreateBossEnemy_King()
        {
            var sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King",true);

            Assert.IsInstanceOfType(enemy,typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateBossEnemy_Queen()
        {
            var sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie Queen",true);

            Assert.IsInstanceOfType(enemy,typeof(BossEnemy));
        }

        [TestMethod]
        public void AreNotSameInstances()
        {
            var sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");
            Enemy anotherEnemy = sut.Create("Zombie");

            Assert.AreNotSame(enemy,anotherEnemy);


        }


    }
}
