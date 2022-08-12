using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            IEnumerable<Knight> knights = players
                .Where(h => h.Weapon != null)
                .OfType<Knight>()
                .Select(x => x as Knight);

            IEnumerable<Barbarian> barbarians = players
                .Where(h => h.Weapon != null)
                .OfType<Barbarian>()
                .Select(x => x as Barbarian);

            int deadKnightsAtStart = knights.Count(x => !x.IsAlive);
            int deadBarabriansAtStart = barbarians.Count(x => !x.IsAlive);

            while (true)
            {
                if(!knights.Any(x => x.IsAlive))
                {
                    return $"The barbarians took {barbarians.Count(x => !x.IsAlive) - deadBarabriansAtStart} casualties but won the battle.";
                }

                if (!barbarians.Any(x => x.IsAlive))
                {
                    return $"The knights took {knights.Count(x => !x.IsAlive) - deadKnightsAtStart} casualties but won the battle.";
                }

                FirstGroupAttackSecondGroup(knights, barbarians);
                FirstGroupAttackSecondGroup(barbarians, knights);
            }

        }

        private void FirstGroupAttackSecondGroup(IEnumerable<IHero> attackingHeroes, IEnumerable<IHero> defendingHeroes)
        {
            foreach (var attackingHero in attackingHeroes)
            {
                if (attackingHero.Weapon == null)
                {
                    continue;
                }

                if (attackingHero.IsAlive)
                {
                    foreach (var defendingHero in defendingHeroes)
                    {
                        if (!defendingHero.IsAlive)
                        {
                            continue;
                        }

                        defendingHero.TakeDamage(attackingHero.Weapon.DoDamage());
                    }
                }
            }
        }
    }
}
