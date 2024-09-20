//using Microsoft.EntityFrameworkCore;
//namespace Monee.Logic.DbLayer
//{
//    /// <summary>
//    /// Database context
//    /// </summary>
//    public class DataBaseContext : DbContext
//    {
//        /// <summary>
//        /// Database context
//        /// </summary>
//        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
//        {
//            #if DEBUG
//                this.Database.SetCommandTimeout(3000);
//            #endif
//        }

//#if DEBUG
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//            => optionsBuilder.LogTo(x => Trace.WriteLine(x) )
//            .EnableSensitiveDataLogging()
//            .EnableDetailedErrors();
//#endif

//        public DbSet<ReportNotification> ReportNotifications { get; set; }

//        public DbSet<OrderNotification> OrderNotifications { get; set; }

//        /// <summary>
//        /// auxiliary set for raw sql query
//        /// </summary>
//        public DbSet<GraphDatePoint> GraphDatePoints { get; set; }

//        /// <summary>
//        /// Products items
//        /// </summary>
//        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

//        /// <summary>
//        /// Payments
//        /// </summary>
//        public virtual DbSet<Payment> Payments { get; set; }

//        /// <summary>
//        /// Payment Payouts
//        /// </summary>
//        public virtual DbSet<PaymentPayout> PaymentPayouts { get; set; }

//        /// <summary>
//        /// Payment Reports
//        /// </summary>
//        public virtual DbSet<PaymentReport> PaymentReports { get; set; }

//        /// <summary>
//        /// Payment Forms
//        /// </summary>
//        public virtual DbSet<PaymentForm> PaymentForms { get; set; }

//        /// <summary>
//        /// Email Templates
//        /// </summary>
//        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

//        /// <summary>
//        /// Payment states
//        /// </summary>
//        public virtual DbSet<UserAccountEmailTemplatePaymentForm> UserAccountEmailTemplatePaymentForms { get; set; }

//        /// <summary>
//        /// Payment states
//        /// </summary>
//        public virtual DbSet<UserAccountMailingSetting> UserAccountMailingSettings { get; set; }

//        /// <summary>
//        /// Payment states
//        /// </summary>
//        public virtual DbSet<PaymentState> PaymentStates { get; set; }

//        /// <summary>
//        /// Order states
//        /// </summary>
//        public virtual DbSet<OrderState> OrderStates { get; set; }

//        /// <summary>
//        /// Payment systems
//        /// </summary>
//        public virtual DbSet<PaymentSystem> PaymentSystems { get; set; }

//        /// <summary>
//        /// Merchant list 
//        /// </summary>
//        public virtual DbSet<Merchant> Merchants { get; set; }

//        /// <summary>
//        /// Merchant moving
//        /// </summary>
//        public virtual DbSet<MerchantMoving> MerchantMovings { get; set; }

//        /// <summary>
//        /// Tax items
//        /// </summary>
//        public virtual DbSet<TaxItem> TaxItems { get; set; }

//        /// <summary>
//        /// Users set
//        /// </summary>
//        public virtual DbSet<UserAccount> UserAccounts { get; set; }
//        public virtual DbSet<NotificationWallet> NotificationsWallet { get; set; }
//        public virtual DbSet<UpdateUserData> UpdateUser { get; set; }
//        public virtual DbSet<StateGuid> StateGuids { get; set; }
//        public virtual DbSet<ListPerson> ListPersons { get; set; }

//        public virtual DbSet<PartnerSetting> PartnersSetting { get; set; }

//        /// <summary>
//        /// User role's
//        /// </summary>
//        public virtual DbSet<UserRole> UserRoles { get; set; }

//        /// <summary>
//        /// Merchant attributes
//        /// </summary>
//        public virtual DbSet<MerchantAttribute> MerchantAttributes { get; set; }

//        /// <summary>
//        /// Payment details
//        /// </summary>
//        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

//        /// <summary>
//        /// Currencies
//        /// </summary>
//        public virtual DbSet<Currency> Currencies { get; set; }

//        /// <summary>
//        /// Payment syste currencies set
//        /// </summary>
//        public virtual DbSet<PaymentSystemCurrencies> PaymentSystemCurrencies { get; set; }

//        /// <summary>
//        /// Payent templates set
//        /// </summary>
//        public virtual DbSet<PaymentTemplate> PaymentTemplates { get; set; }

//        /// <summary>
//        /// Payment system description set
//        /// </summary>
//        public virtual DbSet<PaymentSysStateDescr> PaymentSysStateDescrs { get; set; }

//        /// <summary>
//        /// Jobs set
//        /// </summary>
//        public virtual DbSet<Job> Jobs { get; set; }

//        /// <summary>
//        /// Wallet 
//        /// </summary>
//        public virtual DbSet<Wallet> Wallets { get; set; }

//        /// <summary>
//        /// Wallet 
//        /// </summary>
//        public virtual DbSet<DataForPhon> DataForPhones { get; set; }

//        /// <summary>
//        /// Signature Wallet 
//        /// </summary>
//        public virtual DbSet<SignatureWallet> SignatureWallets { get; set; }

//        /// <summary>
//        /// Transfer betwen wallets 
//        /// </summary>
//        public virtual DbSet<TransferWallets> TransfersWallets { get; set; }

//        /// <summary>
//        /// Transfer betwen wallets 
//        /// </summary>
//        public virtual DbSet<TransferRequest> TransferRequests { get; set; }

//        public virtual DbSet<Fraud> Frauds { get; set; }

//        /// <summary>
//        /// All countries
//        /// </summary>
//        public virtual DbSet<Country> Countries { get; set; }

//        public virtual DbSet<FraudAllowedCountry> FraudAllowedCountries { get; set; }

//        /// <summary>
//        /// Email list for Merchant
//        /// </summary>
//        public virtual DbSet<EmailList> EmailLists { get; set; }

//        /// <summary>
//        /// Merchant allowed Emails
//        /// </summary>
//        public virtual DbSet<FraudAllowedEmail> FraudAllowedEmails { get; set; }

//        /// <summary>
//        /// IP list for Mercahnt
//        /// </summary>
//        public virtual DbSet<IP> IPs { get; set; }

//        /// <summary>
//        /// Merchant allowed IPs
//        /// </summary>
//        public virtual DbSet<FraudAllowedIP> FraudAllowedIPs { get; set; }

//        /// <summary>
//        /// Phone list for Merchant
//        /// </summary>
//        public virtual DbSet<Phone> Phones { get; set; }

//        /// <summary>
//        /// Merchant allowed phones
//        /// </summary>
//        public virtual DbSet<FraudAllowedPhone> FraudAllowedPhones { get; set; }

//        /// <summary>
//        /// role permitions
//        /// </summary>
//        public virtual DbSet<RolePermition> RolePermissions { get; set; }

//        /// <summary>
//        /// Merchant invoice item set
//        /// </summary>
//        public virtual DbSet<MerchantInvoice> MerchantInvoices { get; set; }
//        public virtual DbSet<MerchantInvoiceItem> MerchantInvoiceItems { get; set; }


//        /// <summary>
//        /// Payment token set
//        /// </summary>
//        public virtual DbSet<PaymentToken> PaymentTokens { get; set; }

//        /// <summary>
//        /// CustomerList
//        /// </summary>
//        public virtual DbSet<Customer> Customers { get; set; }
//        public virtual DbSet<AccountStatement> AccountStatements { get; set; }

//        /// <summary>
//        /// Statement setting merchant
//        /// </summary>
//        public virtual DbSet<StatementSetting> StatementSettings { get; set; }

//        /// <summary>
//        /// CustomerList
//        /// </summary>
//        public virtual DbSet<EMail> EMails { get; set; }

//        public virtual DbSet<PropsWallet> RequisitesWallet { get; set; }

//        public virtual DbSet<OrderingPayment> OrderingPayments { get; set; }

//        public virtual DbSet<RecongnitionEntity> RecongnitionTool { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {

//            //modelBuilder.Conventions.AddBefore<System.Data.Entity.ModelConfiguration.Conven‌​tions.ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());

//            base.OnModelCreating(modelBuilder);
//            modelBuilder.ApplyConfiguration(new CutomerConfiguration());

//            modelBuilder.Entity<GraphDatePoint>().HasNoKey();

//            modelBuilder.Entity<EmailList>()
//                .Property(b => b.Adress)
//                .IsRequired();

//            modelBuilder.Entity<EmailList>()
//                .HasIndex(b => b.Adress)
//                .IsUnique();

//            modelBuilder.Entity<IP>()
//                .Property(b => b.Adress)
//                .IsRequired();

//            modelBuilder.Entity<IP>()
//                .HasIndex(b => b.Adress)
//                .IsUnique();

//            modelBuilder.Entity<Phone>()
//                .Property(b => b.Number)
//                .IsRequired();

//            modelBuilder.Entity<Phone>()
//                .HasIndex(b => b.Number)
//                .IsUnique();

//            #region InvoiceItem

//            modelBuilder.Entity<InvoiceItem>()
//                .HasOne(x => x.Payment)
//                .WithMany(x => x.Products)
//                .HasForeignKey("Payment_Id");

//            #endregion

//            #region Payment

//                modelBuilder.Entity<Payment>()
//                .HasOne(x => x.AltCurrency)
//                .WithMany()
//                .HasForeignKey("AltCurrency_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.Currency)
//                .WithMany()
//                .HasForeignKey("Currency_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.Merchant)
//                .WithMany(x => x.Payments)
//                .HasForeignKey(x=>x.Merchant_Id);

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.MerchantInvoice)
//                .WithMany(x => x.PaymentList)
//                .HasForeignKey("MerchantInvoice_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.OrderState)
//                .WithMany()
//                .HasForeignKey("OrderState_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.ParentPayment)
//                .WithMany(x => x.ChildPayments)
//                .HasForeignKey("ParentPayment_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.PaymentCardData)
//                .WithMany()
//                .HasForeignKey("PaymentCardData_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.PaymentDetail)
//                .WithMany()
//                .HasForeignKey("PaymentDetail_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.PaymentState)
//                .WithMany()
//                .HasForeignKey("PaymentState_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.PaymentSysStateDescr)
//                .WithMany()
//                .HasForeignKey("PaymentSysStateDescr_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.PaymentSystem)
//                .WithMany()
//                .HasForeignKey("PaymentSystem_Id");

//            modelBuilder.Entity<Payment>()
//                .HasOne(x => x.Customer)
//                .WithMany(x => x.Payments)
//                .HasForeignKey("Customer_EMail", "Customer_MerchantId");

//            #endregion

//            #region PaymentToken

//            modelBuilder.Entity<PaymentToken>()
//                .HasOne(x => x.Payment)
//                .WithMany()
//                .HasForeignKey("Payment_Id");

//            #endregion

//            #region EMail

//            modelBuilder.Entity<EMail>()
//                .HasOne(x => x.User)
//                .WithMany()
//                .HasForeignKey("User_Id");

//            #endregion

//            #region Merchant

//            modelBuilder.Entity<Merchant>()
//                .HasOne(x => x.Country)
//                .WithMany()
//                .HasForeignKey("Country_Id");

//            modelBuilder.Entity<Merchant>()
//                .HasOne(x => x.PaymentForm)
//                .WithMany(x => x.Merchants)
//                .HasForeignKey("PaymentForm_Id");

//            modelBuilder.Entity<Merchant>()
//                .HasOne(x => x.UserAccount)
//                .WithMany(x => x.Merchants)
//                .HasForeignKey("UserAccount_Id");

//            #endregion

//            #region MerchantAttribute

//            modelBuilder.Entity<MerchantAttribute>()
//                .HasOne(x => x.Merchant)
//                .WithMany(x => x.MerchantAttributes)
//                .HasForeignKey("Merchant_Id");

//            #endregion

//            #region MerchantInvoice

//            modelBuilder.Entity<MerchantInvoice>()
//                .HasOne(x => x.Currency)
//                .WithMany()
//                .HasForeignKey("Currency_Id");

//            modelBuilder.Entity<MerchantInvoice>()
//                .HasOne(x => x.InvoiceForm)
//                .WithMany(x => x.Invoices)
//                .HasForeignKey("InvoiceForm_Id");

//            modelBuilder.Entity<MerchantInvoice>()
//                .HasOne(x => x.Merchant)
//                .WithMany(x => x.MerchantInvoices)
//                .HasForeignKey("Merchant_Id");

//            #endregion

//            #region MerchantMoving

//            modelBuilder.Entity<MerchantMoving>()
//                .HasOne(x => x.Merchant)
//                .WithMany()
//                .HasForeignKey("Merchant_Id");

//            modelBuilder.Entity<MerchantMoving>()
//                .HasOne(x => x.PaymentSystem)
//                .WithMany()
//                .HasForeignKey("PaymentSystem_Id");

//            #endregion

//            #region UserAccountEmailTemplatePaymentForm

//            modelBuilder.Entity<UserAccountEmailTemplatePaymentForm>()
//                .HasOne(x => x.EmailTemplate)
//                .WithMany(x => x.UserAccountEmailTemplatePaymentForms)
//                .HasForeignKey("EmailTemplate_Id");

//            modelBuilder.Entity<UserAccountEmailTemplatePaymentForm>()
//                .HasOne(x => x.PaymentForm)
//                .WithMany(x => x.UserAccountEmailTemplatePaymentForm)
//                .HasForeignKey("PaymentForm_Id");

//            modelBuilder.Entity<UserAccountEmailTemplatePaymentForm>()
//                .HasOne(x => x.UserAccount)
//                .WithMany()
//                .HasForeignKey("UserAccount_Id");

//            #endregion

//            #region UserAccountMailingSetting

//            modelBuilder.Entity<UserAccountMailingSetting>()
//                .HasOne(x => x.EmailTemplate)
//                .WithMany(x => x.UserAccountMailingSettings)
//                .HasForeignKey("EmailTemplate_Id");

//            modelBuilder.Entity<UserAccountMailingSetting>()
//                .HasOne(x => x.UserAccount)
//                .WithMany()
//                .HasForeignKey("UserAccount_Id");

//            #endregion

//            #region PaymentSysStateDescr

//            modelBuilder.Entity<PaymentSysStateDescr>()
//                .HasOne(x => x.PaymentSystem)
//                .WithMany(x => x.States)
//                .HasForeignKey("PaymentSystem_Id");

//            #endregion

//            #region PaymentSystemCurrencies

//            modelBuilder.Entity<PaymentSystemCurrencies>()
//                .HasOne(x => x.Currency)
//                .WithMany()
//                .HasForeignKey("Currency_Id");            

//            modelBuilder.Entity<PaymentSystemCurrencies>()
//                .HasOne(x => x.PaymentSystem)
//                .WithMany(x => x.Currencies)
//                .HasForeignKey("PaymentSystem_Id");

//            #endregion

//            #region PaymentTemplate           

//            modelBuilder.Entity<PaymentTemplate>()
//                .HasOne(x => x.Merchant)
//                .WithMany(x => x.PaymentTemplates)
//                .HasForeignKey("Merchant_Id");

//            #endregion

//            #region TaxItem           

//            modelBuilder.Entity<TaxItem>()
//                .HasOne(x => x.Merchant)
//                .WithMany(x => x.TaxItems)
//                .HasForeignKey("Merchant_Id");

//            modelBuilder.Entity<TaxItem>()
//                .HasOne(x => x.PaymentSystem)
//                .WithMany()
//                .HasForeignKey("PaymentSystem_Id");

//            #endregion

//            #region RolePermition           

//            modelBuilder.Entity<RolePermition>()
//                .HasOne(x => x.UserRole)
//                .WithMany(x => x.Permitions)
//                .HasForeignKey("UserRole_Id");

//            #endregion

//            #region UserAccount           

//            modelBuilder.Entity<UserAccount>()
//                .HasOne(x => x.Country)
//                .WithMany()
//                .HasForeignKey("Country_Id");

//            modelBuilder.Entity<UserAccount>()
//                .HasOne(x => x.UserRole)
//                .WithMany(x => x.Users)
//                .HasForeignKey("UserRole_Id");

//            #endregion

//            modelBuilder.Entity("PaymentFormUserAccount", b =>
//            {
//                b.ToTable("UserAccountPaymentForms");
//            });

//            modelBuilder.Entity("CustomerMerchantInvoice", b =>
//            {
//                b.ToTable("MerchantInvoiceCustomers");
//            });

//            #region MerchantInvoiceItem

//            //modelBuilder.Entity("MerchantInvoiceItem", b =>
//            //{
//            //    b.ToTable("MerchantInvoiceItems");
//            //});

//            //modelBuilder.Entity<MerchantInvoiceItem>()
//            //    .HasOne(x => x.MerchantInvoice)
//            //    .WithMany(x => x.MerchantInvoiceItems)
//            //    .HasForeignKey("MerchantInvoice_Id");

//            #endregion
//        }
//    }
//}
