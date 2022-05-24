using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NetflixTp.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonnement> Abonnements { get; set; }
        public virtual DbSet<DroitsUtilisateur> DroitsUtilisateurs { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmCategorie> FilmCategories { get; set; }
        public virtual DbSet<FilmFilmCategorie> FilmFilmCategories { get; set; }
        public virtual DbSet<Profil> Profils { get; set; }
        public virtual DbSet<ProfilFilm> ProfilFilms { get; set; }
        public virtual DbSet<QuestionsReponse> QuestionsReponses { get; set; }
        public virtual DbSet<Saison> Saisons { get; set; }
        public virtual DbSet<TypeFilm> TypeFilms { get; set; }
        public virtual DbSet<TypeUtilisateur> TypeUtilisateurs { get; set; }
        public virtual DbSet<TypeUtilisateurDroit> TypeUtilisateurDroits { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<UtilisateurProfil> UtilisateurProfils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\netflixDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Abonnement>(entity =>
            {
                entity.HasKey(e => e.IdAbonnement)
                    .HasName("PK__Abonneme__395058AB7DCBA02F");

                entity.ToTable("Abonnement");

                entity.Property(e => e.IdAbonnement).HasColumnName("id_abonnement");

                entity.Property(e => e.AbonnementActif).HasColumnName("abonnement_actif");

                entity.Property(e => e.DebutAbonnement)
                    .HasColumnType("datetime")
                    .HasColumnName("debut_abonnement");

                entity.Property(e => e.FinAbonnement)
                    .HasColumnType("datetime")
                    .HasColumnName("fin_abonnement");

                entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Abonnements)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .HasConstraintName("FK__Abonnemen__id_ut__4301EA8F");
            });

            modelBuilder.Entity<DroitsUtilisateur>(entity =>
            {
                entity.HasKey(e => e.IdDroitsUtilisateurs)
                    .HasName("PK__droits_u__D65097052FA29FED");

                entity.ToTable("droits_utilisateur");

                entity.Property(e => e.IdDroitsUtilisateurs).HasColumnName("id_droits_utilisateurs");

                entity.Property(e => e.NomDroits)
                    .IsUnicode(false)
                    .HasColumnName("nom_droits");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.HasKey(e => e.IdEpisode)
                    .HasName("PK__episode__ADD8EE5845CE5BE5");

                entity.ToTable("episode");

                entity.Property(e => e.IdEpisode).HasColumnName("id_episode");

                entity.Property(e => e.AgeVisualisation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("age_visualisation");

                entity.Property(e => e.AnneeEpisode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("annee_episode");

                entity.Property(e => e.CommentaireEpisode)
                    .IsUnicode(false)
                    .HasColumnName("commentaire_episode");

                entity.Property(e => e.Duree).HasColumnName("duree");

                entity.Property(e => e.IdFilm).HasColumnName("id_film");

                entity.Property(e => e.IdSaison).HasColumnName("id_saison");

                entity.Property(e => e.LienVideo)
                    .IsUnicode(false)
                    .HasColumnName("lien_video");

                entity.Property(e => e.NbVues).HasColumnName("nb_vues");

                entity.Property(e => e.NomEpisode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_episode");

                entity.Property(e => e.Realisateur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("realisateur");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.IdFilm)
                    .HasConstraintName("FK__episode__id_film__542C7691");

                entity.HasOne(d => d.IdSaisonNavigation)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.IdSaison)
                    .HasConstraintName("FK__episode__id_sais__55209ACA");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.IdFilm)
                    .HasName("PK__film__648EA6D7D06A0D09");

                entity.ToTable("film");

                entity.Property(e => e.IdFilm).HasColumnName("id_film");

                entity.Property(e => e.AnneeFilm)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("annee_film");

                entity.Property(e => e.CommentaireFilm)
                    .IsUnicode(false)
                    .HasColumnName("commentaire_film");

                entity.Property(e => e.IdTypeFilm).HasColumnName("id_type_film");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titre");

                entity.HasOne(d => d.IdTypeFilmNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdTypeFilm)
                    .HasConstraintName("FK__film__id_type_fi__4F67C174");
            });

            modelBuilder.Entity<FilmCategorie>(entity =>
            {
                entity.HasKey(e => e.IdFilmCategorie)
                    .HasName("PK__film_cat__A088959CE852A9CD");

                entity.ToTable("film_categorie");

                entity.Property(e => e.IdFilmCategorie).HasColumnName("id_film_categorie");

                entity.Property(e => e.NomCategorie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nom_categorie");
            });

            modelBuilder.Entity<FilmFilmCategorie>(entity =>
            {
                entity.HasKey(e => new { e.IdFilm, e.IdFilmCategorie })
                    .HasName("film_film_categorie_PK");

                entity.ToTable("film_film_categorie");

                entity.Property(e => e.IdFilm).HasColumnName("id_film");

                entity.Property(e => e.IdFilmCategorie).HasColumnName("id_film_categorie");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.FilmFilmCategories)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_film_categorie_film_FK");

                entity.HasOne(d => d.IdFilmCategorieNavigation)
                    .WithMany(p => p.FilmFilmCategories)
                    .HasForeignKey(d => d.IdFilmCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_film_categorie_film_categorie_FK");
            });

            modelBuilder.Entity<Profil>(entity =>
            {
                entity.HasKey(e => e.IdProfil)
                    .HasName("PK__profil__35CEA0E94E82C3D8");

                entity.ToTable("profil");

                entity.Property(e => e.IdProfil).HasColumnName("id_profil");

                entity.Property(e => e.NomProfil)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nom_profil");

                entity.Property(e => e.TypeProfil)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type_profil");
            });

            modelBuilder.Entity<ProfilFilm>(entity =>
            {
                entity.HasKey(e => new { e.IdProfil, e.IdFilm })
                    .HasName("profil_film_pk");

                entity.ToTable("profil_film");

                entity.Property(e => e.IdProfil).HasColumnName("id_profil");

                entity.Property(e => e.IdFilm).HasColumnName("id_film");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.ProfilFilms)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profil_film_film_fk");

                entity.HasOne(d => d.IdProfilNavigation)
                    .WithMany(p => p.ProfilFilms)
                    .HasForeignKey(d => d.IdProfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profil_film_profil_fk");
            });

            modelBuilder.Entity<QuestionsReponse>(entity =>
            {
                entity.HasKey(e => e.IdQuestionReponse)
                    .HasName("PK__question__BE0A1F652381406A");

                entity.ToTable("questions_reponses");

                entity.Property(e => e.IdQuestionReponse).HasColumnName("id_question_reponse");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.Property(e => e.Reponse)
                    .IsUnicode(false)
                    .HasColumnName("reponse");
            });

            modelBuilder.Entity<Saison>(entity =>
            {
                entity.HasKey(e => e.IdSaison)
                    .HasName("PK__saison__59731C6370C998D5");

                entity.ToTable("saison");

                entity.Property(e => e.IdSaison).HasColumnName("id_saison");

                entity.Property(e => e.CommentaireSaison)
                    .IsUnicode(false)
                    .HasColumnName("commentaire_saison");

                entity.Property(e => e.NomSaison)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_saison");
            });

            modelBuilder.Entity<TypeFilm>(entity =>
            {
                entity.HasKey(e => e.IdTypeFilm)
                    .HasName("PK__type_fil__0F6F411FD760631F");

                entity.ToTable("type_film");

                entity.Property(e => e.IdTypeFilm).HasColumnName("id_type_film");

                entity.Property(e => e.NomTypeFilm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_type_film");
            });

            modelBuilder.Entity<TypeUtilisateur>(entity =>
            {
                entity.HasKey(e => e.IdTypeUtilisateur)
                    .HasName("PK__type_uti__8C035B79626892F7");

                entity.ToTable("type_utilisateur");

                entity.Property(e => e.IdTypeUtilisateur).HasColumnName("id_type_utilisateur");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            });

            modelBuilder.Entity<TypeUtilisateurDroit>(entity =>
            {
                entity.HasKey(e => new { e.IdTypeUtilisateur, e.IdDroitsUtilisateurs })
                    .HasName("type_utilisateur_droits_PK");

                entity.ToTable("type_utilisateur_droits");

                entity.Property(e => e.IdTypeUtilisateur).HasColumnName("id_type_utilisateur");

                entity.Property(e => e.IdDroitsUtilisateurs).HasColumnName("id_droits_utilisateurs");

                entity.HasOne(d => d.IdDroitsUtilisateursNavigation)
                    .WithMany(p => p.TypeUtilisateurDroits)
                    .HasForeignKey(d => d.IdDroitsUtilisateurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("type_utilisateur_droits_droits_utilisateur_FK");

                entity.HasOne(d => d.IdTypeUtilisateurNavigation)
                    .WithMany(p => p.TypeUtilisateurDroits)
                    .HasForeignKey(d => d.IdTypeUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("type_utilisateur_droits_type_utilisateur_FK");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PK__utilisat__1A4FA5B809C7DC22");

                entity.ToTable("utilisateur");

                entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");

                entity.Property(e => e.DateNaissance)
                    .HasColumnType("datetime")
                    .HasColumnName("date_naissance");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTypeUtilisateur).HasColumnName("id_type_utilisateur");

                entity.Property(e => e.Mdp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mdp");

                entity.Property(e => e.NomProfil)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nom_profil");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("prenom");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.HasOne(d => d.IdTypeUtilisateurNavigation)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdTypeUtilisateur)
                    .HasConstraintName("FK__utilisate__id_ty__3A6CA48E");
            });

            modelBuilder.Entity<UtilisateurProfil>(entity =>
            {
                entity.HasKey(e => new { e.IdUtilisateur, e.IdProfil })
                    .HasName("utilisateur_profil_PK");

                entity.ToTable("utilisateur_profil");

                entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");

                entity.Property(e => e.IdProfil).HasColumnName("id_profil");

                entity.HasOne(d => d.IdProfilNavigation)
                    .WithMany(p => p.UtilisateurProfils)
                    .HasForeignKey(d => d.IdProfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilisateur_profil_profil_FK");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.UtilisateurProfils)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilisateur_profil_utilisateur_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
