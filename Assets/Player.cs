using System;
using UnityEngine;


public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; }

    public event EventHandler<HealedEventArgs> Healed;
    public event EventHandler<DamagedEventArgs> Damaged;

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException(nameof(currentHealth));
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException(nameof(currentHealth));
        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        var newHealth = Mathf.Min(CurrentHealth + amount, MaximumHealth);
        if (Healed != null) Healed(this, new HealedEventArgs(newHealth - CurrentHealth));
        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        var newHealth = Mathf.Max(CurrentHealth - amount, 0);
        if(Damaged != null) Damaged(this, new DamagedEventArgs(CurrentHealth - newHealth));

        CurrentHealth = newHealth;
    }

    public class HealedEventArgs : EventArgs
    {
        public int Amount { get; set; }

        public HealedEventArgs(int amount)
        {
            Amount = amount;
        }
    }

    public class DamagedEventArgs : EventArgs
    {
        public int Amount { get; set; }

        public DamagedEventArgs(int amount)
        {
            Amount = amount;
        }
    }
}