using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{   
   [TestClass]
   [TestCategory(TestCategories.BOSS_ENEMY_CREATION)]
   public class BossCharacterShould
    {
       

        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {
            var sut = new BossEnemy();

            Assert.AreEqual(166.66,sut.SpecialAttackPower,0.07);

        }

    }
}
