using DiplomUchetSC.Context;
using DiplomUchetSC.Enums;
using DiplomUchetSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DiplomUchetSC.Views.Pages.MainPages
{
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var today = DateTime.Today;
                    var monthAgo = today.AddDays(-30);

                    var todayOrders = db.Orders
                        .Include(o => o.Client)
                        .Include(o => o.DeviceType)
                        .Where(o => o.Created_at >= today && o.Created_at < today.AddDays(1))
                        .ToList();

                    UpdateTodayStats(todayOrders, db);
                    UpdateMonthStats(db, today, monthAgo);
                    UpdateAllTimeStats(db);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}");
            }
        }

        private void UpdateTodayStats(System.Collections.Generic.List<Order> todayOrders, ApplicationContext db)
        {
            TodayAcceptedText.Text = $"Принято: {todayOrders.Count}";
            TodayIssuedText.Text = $"Выдано: {todayOrders.Count(o => o.OrderStatus == OrderStatus.ISSUED)}";
            TodayGuaranteeText.Text = $"По гарантии: {todayOrders.Count(o => o.Is_guarantee)}";

            TodayEarnedText.Text = $"Заработано: {todayOrders.Sum(o => o.Final_cost)} руб.";
            TodayAvgCostText.Text = $"Средний чек: {(todayOrders.Any() ? todayOrders.Average(o => o.Final_cost) : 0)} руб.";


        }

        private void UpdateMonthStats(ApplicationContext db, DateTime today, DateTime monthAgo)
        {
            var monthOrders = db.Orders
                .Include(o => o.Client)
                .Include(o => o.DeviceType)
                .Where(o => o.Created_at >= monthAgo && o.Created_at < today.AddDays(1))
                .ToList();

            MonthAcceptedText.Text = $"Принято: {monthOrders.Count}";
            MonthIssuedText.Text = $"Выдано: {monthOrders.Count(o => o.OrderStatus == OrderStatus.ISSUED)}";
            MonthGuaranteeText.Text = $"По гарантии: {monthOrders.Count(o => o.Is_guarantee)}";

            MonthEarnedText.Text = $"Заработано: {monthOrders.Sum(o => o.Final_cost)} руб.";
            MonthAvgCostText.Text = $"Средний чек: {(monthOrders.Any() ? Math.Round(monthOrders.Average(o => o.Final_cost), 2) : 0)} руб.";

            var monthAvgRepairTime = monthOrders
                .Where(o => o.OrderStatus == OrderStatus.ISSUED)
                .Average(o => (o.Issued_at - o.Created_at)?.TotalDays);
            MonthAvgRepairTimeText.Text = $"Среднее время: {monthAvgRepairTime?.ToString("0.0") ?? "-"} дн.";

            var clientIdsInMonth = monthOrders
                .Select(o => o.Client.Id)
                .Distinct()
                .ToList();

            var newClientsCount = clientIdsInMonth
                .Count(clientId => !db.Orders.Any(o => o.Client.Id == clientId && o.Created_at < monthAgo));

            var repeatClientsCount = clientIdsInMonth.Count - newClientsCount;

            MonthClientsStatsText.Text = $"Клиенты: {clientIdsInMonth.Count} (Новых: {newClientsCount}, Повторных: {repeatClientsCount})";

            var monthTopDevices = monthOrders
                .Where(o => o.DeviceType != null)
                .GroupBy(o => o.DeviceType.Name)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => $"{g.Key} - {g.Count()} шт.")
                .ToList();
            MonthTopDevicesList.ItemsSource = monthTopDevices;
        }

        private void UpdateAllTimeStats(ApplicationContext db)
        {
            var allTimeOrders = db.Orders
                .Include(o => o.Client)
                .Include(o => o.DeviceType)
                .ToList();

            AllTimeAcceptedText.Text = $"Принято: {allTimeOrders.Count}";
            AllTimeIssuedText.Text = $"Выдано: {allTimeOrders.Count(o => o.OrderStatus == OrderStatus.ISSUED)}";
            AllTimeGuaranteeText.Text = $"По гарантии: {allTimeOrders.Count(o => o.Is_guarantee)}";

            AllTimeEarnedText.Text = $"Заработано: {allTimeOrders.Sum(o => o.Final_cost)} руб.";
            AllTimeAvgCostText.Text = $"Средний чек: {(allTimeOrders.Any() ? Math.Round(allTimeOrders.Average(o => o.Final_cost), 2) : 0)} руб.";

            var allTimeAvgRepairTime = allTimeOrders
                .Where(o => o.OrderStatus == OrderStatus.ISSUED)
                .Average(o => (o.Issued_at - o.Created_at)?.TotalDays);
            AllTimeAvgRepairTimeText.Text = $"Среднее время: {allTimeAvgRepairTime?.ToString("0.0") ?? "-"} дн.";

            var allClients = allTimeOrders.Select(o => o.Client).Distinct().Count();
            var repeatClients = allTimeOrders
                .GroupBy(o => o.Client.Id)
                .Count(g => g.Count() > 1);
            var topClient = allTimeOrders
                .GroupBy(o => o.Client)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?
                .Key;

            AllTimeNewClientsText.Text = $"Всего клиентов: {allClients}";
            AllTimeRepeatClientsText.Text = $"Повторных клиентов: {repeatClients}";
            AllTimeTopClientText.Text = $"Топ-клиент: {topClient?.Full_name ?? "нет данных"} ({allTimeOrders.Count(o => o.Client == topClient)} заказов)";

            var allTimeTopDevices = allTimeOrders
                .Where(o => o.DeviceType != null)
                .GroupBy(o => o.DeviceType.Name)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => $"{g.Key} - {g.Count()} шт.")
                .ToList();
            AllTimeTopDevicesList.ItemsSource = allTimeTopDevices;
        }
    }
}