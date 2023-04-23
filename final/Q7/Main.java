package org.example;

public class Main {

    public static int accountBalance = 0;
    public static void main(String[] args) {

        BankAccount account = new BankAccount();
        Thread[] addThreads = new Thread[4];
        Thread[] takeoutThreads = new Thread[5];

        for (int i = 0; i < addThreads.length; i++) {
            addThreads[i] = new Thread(() -> {
                for (int j = 0; j <= 4; j++) {
                    account.add(1);
                }
            }, "Deposit Thread " + (i + 1));
        }

        for (int i = 0; i < takeoutThreads.length; i++) {
            takeoutThreads[i] = new Thread(() -> {
                for (int j = 0; j <= 5; j++) {
                    account.takeOut(1);
                }
            }, "Withdraw Thread " + (i + 1));
        }
        for (Thread thread : addThreads) {
            thread.start();
        }

        for (Thread thread : takeoutThreads) {
            thread.start();
        }
    }
}