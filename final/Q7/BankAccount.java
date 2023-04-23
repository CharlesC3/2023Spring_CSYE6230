package org.example;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class BankAccount {
    private int balance;
    private Lock lock;

    public BankAccount() {
        this.balance = 0;
        this.lock = new ReentrantLock();
    }

    public void add(int amount) {
        balance += amount;
        System.out.println(Thread.currentThread().getName() + " add " + amount + ". New balance: " + balance);
    }

    public void takeOut(int amount) {
        if (balance >= amount) {
            balance -= amount;
            System.out.println(Thread.currentThread().getName() + " take out" + amount + ". New balance: " + balance);
        } else {
            System.out.println(Thread.currentThread().getName() + " cannot take out " + amount + ". Insufficient balance.");
        }
    }
}