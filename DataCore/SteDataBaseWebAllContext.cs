using System;
using DomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataCore
{
    public partial class SteDataBaseWebAllContext : DbContext
    {
        public SteDataBaseWebAllContext()
        {
        }

        public SteDataBaseWebAllContext(DbContextOptions<SteDataBaseWebAllContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avoir> Avoirs { get; set; }
        public virtual DbSet<AvoirFinancierFournisseur> AvoirFinancierFournisseurs { get; set; }
        public virtual DbSet<AvoirFournisseur> AvoirFournisseurs { get; set; }
        public virtual DbSet<BonDeLivraison> BonDeLivraisons { get; set; }
        public virtual DbSet<BonDeReception> BonDeReceptions { get; set; }
        public  DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Devi> Devis { get; set; }
        public virtual DbSet<EcheanceDesFournisseur> EcheanceDesFournisseurs { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<FactureAvoirFournisseur> FactureAvoirFournisseurs { get; set; }
        public virtual DbSet<FactureFournisseur> FactureFournisseurs { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<LigneAvoir> LigneAvoirs { get; set; }
        public virtual DbSet<LigneAvoirFournisseur> LigneAvoirFournisseurs { get; set; }
        public virtual DbSet<LigneBl> LigneBls { get; set; }
        public virtual DbSet<LigneBonReception> LigneBonReceptions { get; set; }
        public virtual DbSet<LigneCommande> LigneCommandes { get; set; }
        public virtual DbSet<LigneDevi> LigneDevis { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Systeme> Systemes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=.\\;initial catalog=SteDataBaseWebAll;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avoir>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.Avoirs");

                entity.HasIndex(e => e.ClientId, "IX_clientId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Avoirs)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_dbo.Avoirs_dbo.Client_clientId");
            });

            modelBuilder.Entity<AvoirFinancierFournisseur>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.AvoirFinancierFournisseurs");

                entity.HasIndex(e => e.Num, "IX_Num");

                entity.Property(e => e.Num).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_ttc");

                entity.HasOne(d => d.NumNavigation)
                    .WithOne(p => p.AvoirFinancierFournisseur)
                    .HasForeignKey<AvoirFinancierFournisseur>(d => d.Num)
                    .HasConstraintName("FK_dbo.AvoirFinancierFournisseurs_dbo.FactureFournisseur_Num");
            });

            modelBuilder.Entity<AvoirFournisseur>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.AvoirFournisseur");

                entity.ToTable("AvoirFournisseur");

                entity.HasIndex(e => e.NumFactureAvoirFournisseur, "IX_Num_FactureAvoirFournisseur");

                entity.HasIndex(e => e.FournisseurId, "IX_fournisseurId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.FournisseurId).HasColumnName("fournisseurId");

                entity.Property(e => e.NumAvoirFournisseur).HasColumnName("Num_AvoirFournisseur");

                entity.Property(e => e.NumFactureAvoirFournisseur).HasColumnName("Num_FactureAvoirFournisseur");

                entity.HasOne(d => d.Fournisseur)
                    .WithMany(p => p.AvoirFournisseurs)
                    .HasForeignKey(d => d.FournisseurId)
                    .HasConstraintName("FK_dbo.AvoirFournisseur_dbo.Fournisseur_fournisseurId");

                entity.HasOne(d => d.NumFactureAvoirFournisseurNavigation)
                    .WithMany(p => p.AvoirFournisseurs)
                    .HasForeignKey(d => d.NumFactureAvoirFournisseur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AvoirFournisseur_dbo.FactureAvoirFournisseur_Num_FactureAvoirFournisseur");
            });

            modelBuilder.Entity<BonDeLivraison>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.BonDeLivraison");

                entity.ToTable("BonDeLivraison");

                entity.HasIndex(e => e.NumFacture, "IX_Num_Facture");

                entity.HasIndex(e => e.ClientId, "IX_clientId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.NetPayer)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("net_payer");

                entity.Property(e => e.NumFacture).HasColumnName("Num_Facture");

                entity.Property(e => e.TempBl).HasColumnName("temp_bl");

                entity.Property(e => e.TotHTva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_H_tva");

                entity.Property(e => e.TotTva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_tva");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.BonDeLivraisons)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_dbo.BonDeLivraison_dbo.Client_clientId");

                entity.HasOne(d => d.NumFactureNavigation)
                    .WithMany(p => p.BonDeLivraisons)
                    .HasForeignKey(d => d.NumFacture)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.BonDeLivraison_dbo.Facture_Num_Facture");
            });

            modelBuilder.Entity<BonDeReception>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.BonDeReception");

                entity.ToTable("BonDeReception");

                entity.HasIndex(e => e.NumFactureFournisseur, "IX_Num_Facture_fournisseur");

                entity.HasIndex(e => e.IdFournisseur, "IX_id_fournisseur");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.DateLivraison)
                    .HasColumnType("datetime")
                    .HasColumnName("date_livraison");

                entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");

                entity.Property(e => e.NumBonFournisseur).HasColumnName("Num_Bon_fournisseur");

                entity.Property(e => e.NumFactureFournisseur).HasColumnName("Num_Facture_fournisseur");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.BonDeReceptions)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.BonDeReception_dbo.Fournisseur_id_fournisseur");

                entity.HasOne(d => d.NumFactureFournisseurNavigation)
                    .WithMany(p => p.BonDeReceptions)
                    .HasForeignKey(d => d.NumFactureFournisseur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.BonDeReception_dbo.FactureFournisseur_Num_Facture_fournisseur");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeCat).HasColumnName("code_cat");

                entity.Property(e => e.EtbSec).HasColumnName("etb_sec");

                entity.Property(e => e.Mail).HasColumnName("mail");

                entity.Property(e => e.Matricule).HasColumnName("matricule");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.Commandes");

                entity.HasIndex(e => e.FournisseurId, "IX_fournisseurId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.FournisseurId).HasColumnName("fournisseurId");

                entity.HasOne(d => d.Fournisseur)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.FournisseurId)
                    .HasConstraintName("FK_dbo.Commandes_dbo.Fournisseur_fournisseurId");
            });

            modelBuilder.Entity<Devi>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.Devis");

                entity.HasIndex(e => e.IdClient, "IX_id_client");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.TotHTva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_H_tva");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_ttc");

                entity.Property(e => e.TotTva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_tva");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Devis)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_dbo.Devis_dbo.Client_id_client");
            });

            modelBuilder.Entity<EcheanceDesFournisseur>(entity =>
            {
                entity.HasIndex(e => e.FournisseurId, "IX_fournisseur_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateEcheance)
                    .HasColumnType("datetime")
                    .HasColumnName("dateEcheance");

                entity.Property(e => e.FournisseurId).HasColumnName("fournisseur_id");

                entity.Property(e => e.Montant)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("montant");

                entity.Property(e => e.NumCheque).HasColumnName("numCheque");

                entity.HasOne(d => d.Fournisseur)
                    .WithMany(p => p.EcheanceDesFournisseurs)
                    .HasForeignKey(d => d.FournisseurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EcheanceDesFournisseurs_dbo.Fournisseur_fournisseur_id");
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.Facture");

                entity.ToTable("Facture");

                entity.HasIndex(e => e.IdClient, "IX_id_client");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Facture_dbo.Client_id_client");
            });

            modelBuilder.Entity<FactureAvoirFournisseur>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.FactureAvoirFournisseur");

                entity.ToTable("FactureAvoirFournisseur");

                entity.HasIndex(e => e.NumFactureFournisseur, "IX_FactureFournisseur_Num");

                entity.HasIndex(e => e.IdFournisseur, "IX_id_fournisseur");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");

                entity.Property(e => e.NumFactureAvoirFourSurPage).HasColumnName("Num_FactureAvoirFourSurPAge");

                entity.Property(e => e.NumFactureFournisseur).HasColumnName("Num_FactureFournisseur");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.FactureAvoirFournisseurs)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.FactureAvoirFournisseur_dbo.Fournisseur_id_fournisseur");

                entity.HasOne(d => d.NumFactureFournisseurNavigation)
                    .WithMany(p => p.FactureAvoirFournisseurs)
                    .HasForeignKey(d => d.NumFactureFournisseur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.FactureAvoirFournisseur_dbo.FactureFournisseur_Num_FactureFournisseur");
            });

            modelBuilder.Entity<FactureFournisseur>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK_dbo.FactureFournisseur");

                entity.ToTable("FactureFournisseur");

                entity.HasIndex(e => e.IdFournisseur, "IX_id_fournisseur");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.DateFacturationFournisseur)
                    .HasColumnType("datetime")
                    .HasColumnName("dateFacturationFournisseur");

                entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");

                entity.Property(e => e.Paye).HasColumnName("paye");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.FactureFournisseurs)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.FactureFournisseur_dbo.Fournisseur_id_fournisseur");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("Fournisseur");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresse).HasColumnName("adresse");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.CodeCat)
                    .HasMaxLength(50)
                    .HasColumnName("code_cat");

                entity.Property(e => e.Constructeur).HasColumnName("constructeur");

                entity.Property(e => e.EtbSec)
                    .HasMaxLength(50)
                    .HasColumnName("etb_sec");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .HasColumnName("fax");

                entity.Property(e => e.Mail).HasColumnName("mail");

                entity.Property(e => e.MailDeux).HasColumnName("mail_deux");

                entity.Property(e => e.Matricule)
                    .HasMaxLength(50)
                    .HasColumnName("matricule");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<LigneAvoir>(entity =>
            {
                entity.HasKey(e => e.IdLi)
                    .HasName("PK_dbo.LigneAvoirs");

                entity.HasIndex(e => e.NumAvoir, "IX_Num_avoir");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_Produit");

                entity.Property(e => e.IdLi).HasColumnName("Id_li");

                entity.Property(e => e.DesignationLi).HasColumnName("designation_li");

                entity.Property(e => e.NumAvoir).HasColumnName("Num_avoir");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_Produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumAvoirNavigation)
                    .WithMany(p => p.LigneAvoirs)
                    .HasForeignKey(d => d.NumAvoir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneAvoirs_dbo.Avoirs_Num_avoir");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneAvoirs)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneAvoirs_dbo.Produit_Ref_Produit");
            });

            modelBuilder.Entity<LigneAvoirFournisseur>(entity =>
            {
                entity.HasKey(e => e.IdLi)
                    .HasName("PK_dbo.LigneAvoirFournisseur");

                entity.ToTable("LigneAvoirFournisseur");

                entity.HasIndex(e => e.NumAvoirFr, "IX_Num_AvoirFr");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_Produit");

                entity.Property(e => e.IdLi).HasColumnName("Id_li");

                entity.Property(e => e.DesignationLi)
                    .IsRequired()
                    .HasColumnName("designation_li");

                entity.Property(e => e.NumAvoirFr).HasColumnName("Num_AvoirFr");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_Produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumAvoirFrNavigation)
                    .WithMany(p => p.LigneAvoirFournisseurs)
                    .HasForeignKey(d => d.NumAvoirFr)
                    .HasConstraintName("FK_dbo.LigneAvoirFournisseur_dbo.AvoirFournisseur_Num_AvoirFr");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneAvoirFournisseurs)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneAvoirFournisseur_dbo.Produit_Ref_Produit");
            });

            modelBuilder.Entity<LigneBl>(entity =>
            {
                entity.HasKey(e => e.IdLi)
                    .HasName("PK_dbo.LigneBL");

                entity.ToTable("LigneBL");

                entity.HasIndex(e => e.NumBl, "IX_Num_BL");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_Produit");

                entity.Property(e => e.IdLi).HasColumnName("Id_li");

                entity.Property(e => e.DesignationLi)
                    .IsRequired()
                    .HasColumnName("designation_li");

                entity.Property(e => e.NumBl).HasColumnName("Num_BL");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_Produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumBlNavigation)
                    .WithMany(p => p.LigneBls)
                    .HasForeignKey(d => d.NumBl)
                    .HasConstraintName("FK_dbo.LigneBL_dbo.BonDeLivraison_Num_BL");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneBls)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneBL_dbo.Produit_Ref_Produit");
            });

            modelBuilder.Entity<LigneBonReception>(entity =>
            {
                entity.HasKey(e => e.IdLigne)
                    .HasName("PK_dbo.LigneBonReception");

                entity.ToTable("LigneBonReception");

                entity.HasIndex(e => e.NumBonRec, "IX_Num_BonRec");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_Produit");

                entity.Property(e => e.IdLigne).HasColumnName("Id_ligne");

                entity.Property(e => e.DesignationLi)
                    .IsRequired()
                    .HasColumnName("designation_li");

                entity.Property(e => e.NumBonRec).HasColumnName("Num_BonRec");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_Produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumBonRecNavigation)
                    .WithMany(p => p.LigneBonReceptions)
                    .HasForeignKey(d => d.NumBonRec)
                    .HasConstraintName("FK_dbo.LigneBonReception_dbo.BonDeReception_Num_BonRec");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneBonReceptions)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneBonReception_dbo.Produit_Ref_Produit");
            });

            modelBuilder.Entity<LigneCommande>(entity =>
            {
                entity.HasKey(e => e.IdLi)
                    .HasName("PK_dbo.LigneCommandes");

                entity.HasIndex(e => e.NumCommande, "IX_Num_commande");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_Produit");

                entity.Property(e => e.IdLi).HasColumnName("Id_li");

                entity.Property(e => e.DesignationLi).HasColumnName("designation_li");

                entity.Property(e => e.NumCommande).HasColumnName("Num_commande");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_Produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumCommandeNavigation)
                    .WithMany(p => p.LigneCommandes)
                    .HasForeignKey(d => d.NumCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneCommandes_dbo.Commandes_Num_commande");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneCommandes)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneCommandes_dbo.Produit_Ref_Produit");
            });

            modelBuilder.Entity<LigneDevi>(entity =>
            {
                entity.HasKey(e => e.IdLi)
                    .HasName("PK_dbo.LigneDevis");

                entity.HasIndex(e => e.NumDevis, "IX_Num_devis");

                entity.HasIndex(e => e.RefProduit, "IX_Ref_produit");

                entity.Property(e => e.IdLi).HasColumnName("Id_li");

                entity.Property(e => e.DesignationLi)
                    .IsRequired()
                    .HasColumnName("Designation_li");

                entity.Property(e => e.NumDevis).HasColumnName("Num_devis");

                entity.Property(e => e.PrixHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix_HT");

                entity.Property(e => e.QteLi).HasColumnName("qte_li");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ref_produit");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.TotHt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_HT");

                entity.Property(e => e.TotTtc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tot_TTC");

                entity.Property(e => e.Tva).HasColumnName("tva");

                entity.HasOne(d => d.NumDevisNavigation)
                    .WithMany(p => p.LigneDevis)
                    .HasForeignKey(d => d.NumDevis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneDevis_dbo.Devis_Num_devis");

                entity.HasOne(d => d.RefProduitNavigation)
                    .WithMany(p => p.LigneDevis)
                    .HasForeignKey(d => d.RefProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LigneDevis_dbo.Produit_Ref_produit");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Refe)
                    .HasName("PK_dbo.Produit");

                entity.ToTable("Produit");

                entity.Property(e => e.Refe)
                    .HasMaxLength(50)
                    .HasColumnName("refe");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom");

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix");

                entity.Property(e => e.PrixAchat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prixAchat");

                entity.Property(e => e.Qte).HasColumnName("qte");

                entity.Property(e => e.QteLimite).HasColumnName("qteLimite");

                entity.Property(e => e.Remise).HasColumnName("remise");

                entity.Property(e => e.RemiseAchat).HasColumnName("remiseAchat");

                entity.Property(e => e.Tva).HasColumnName("TVA");

                entity.Property(e => e.Visibilite).HasColumnName("visibilite");
            });

            modelBuilder.Entity<Systeme>(entity =>
            {
                entity.ToTable("Systeme");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse");

                entity.Property(e => e.AdresseRetenu).HasColumnName("adresseRetenu");

                entity.Property(e => e.CodeCategorie).HasColumnName("codeCategorie");

                entity.Property(e => e.CodeTva)
                    .IsRequired()
                    .HasColumnName("codeTVA");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EtbSecondaire).HasColumnName("etbSecondaire");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.MatriculeFiscale).HasColumnName("matriculeFiscale");

                entity.Property(e => e.NomSociete)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PourcentageFodec)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pourcentageFodec");

                entity.Property(e => e.PourcentageRetenu).HasColumnName("pourcentageRetenu");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel");

                entity.Property(e => e.Timbre).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.NumBl)
                    .HasName("PK_dbo.Transaction");

                entity.ToTable("Transaction");

                entity.HasIndex(e => e.NumBl, "IX_Num_BL");

                entity.Property(e => e.NumBl)
                    .ValueGeneratedNever()
                    .HasColumnName("Num_BL");

                entity.Property(e => e.DateTr)
                    .HasColumnType("datetime")
                    .HasColumnName("date_tr");

                entity.Property(e => e.Montant)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("montant");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.NumBlNavigation)
                    .WithOne(p => p.Transaction)
                    .HasForeignKey<Transaction>(d => d.NumBl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Transaction_dbo.BonDeLivraison_Num_BL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
