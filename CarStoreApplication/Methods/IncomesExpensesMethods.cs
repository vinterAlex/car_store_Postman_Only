using CarStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreApplication.Methods
{
    public class IncomesExpensesMethods
    {

       public int Budget()
        {
            var income = GetTotalIncome();
            var expense = GetTotalExpenses();

            var budgetTotal = income - expense;

            return budgetTotal;
        }


        public int GetTotalIncome()
        {

            var incomes = new List<Incomes>();


            incomes.Add(new Incomes() { id = 1, description = "salary", value = 5500 });
            incomes.Add(new Incomes() { id = 2, description = "bonus", value = 100 });
            incomes.Add(new Incomes() { id = 3, description = "onCall", value = 500 });

            var total = incomes.Sum(item => item.value);

            return total;
        }

        public int GetTotalExpenses()
        {
            var expenses = new List<Expenses>();

            expenses.Add(new Expenses() { id = 1, description = "Fuel", value = 1500 });
            expenses.Add(new Expenses() { id = 2, description = "Energy", value = 100 });
            expenses.Add(new Expenses() { id = 3, description = "Patience", value = 500 });
            expenses.Add(new Expenses() { id = 4, description = "Food", value = 2 });

            var total = expenses.Sum(item => item.value);

            return total;
        }

        public List<Incomes>  GetIncomes()
        {

            var incomes = new List<Incomes>();
         

                incomes.Add(new Incomes() { id = 1, description = "salary", value = 5500 });
                incomes.Add(new Incomes() { id = 2, description = "bonus", value = 100 });
                incomes.Add(new Incomes() { id = 3, description = "onCall", value = 500 });
        
            //var total = incomes.Sum(item => item.value);
            //incomeParam = total;
            
            //totalIncome = incomes.Sum(item => item.value); 

            return incomes;
            
        }


        public List<Expenses> GetExpenses()
        {
            var expenses = new List<Expenses>();

            expenses.Add(new Expenses() { id = 1, description = "Fuel", value = 1500 });
            expenses.Add(new Expenses() { id = 2, description = "Energy", value = 100 });
            expenses.Add(new Expenses() { id = 3, description = "Patience", value = 500 });
            expenses.Add(new Expenses() { id = 4, description = "Food", value =2 });

            return expenses.ToList();
        }



    }
}
