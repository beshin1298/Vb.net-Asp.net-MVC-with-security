Imports System.Data.Entity

Partial Public Class DatabaseContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=DefaultConnection")
    End Sub

    Public Overridable Property category As DbSet(Of category)
    Public Overridable Property product As DbSet(Of product)
    Public Overridable Property AspNetRoles As DbSet(Of AspNetRoles)
    Public Overridable Property AspNetUserClaims As DbSet(Of AspNetUserClaims)
    Public Overridable Property AspNetUserLogins As DbSet(Of AspNetUserLogins)
    Public Overridable Property AspNetUserRoles As DbSet(Of AspNetUserRoles)
    Public Overridable Property AspNetUsers As DbSet(Of AspNetUsers)
    Public Overridable Property UserCart As DbSet(Of UserCart)
    Public Overridable Property CartView As DbSet(Of CartView)
    Public Overridable Property ComputerDevice As DbSet(Of ComputerDevice)
    Public Overridable Property Comment As DbSet(Of comment)
    Public Overridable Property OdersView As DbSet(Of OrdersView)
    Public Overridable Property OrderShpping As DbSet(Of order_shipping)



    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of category)() _
            .HasMany(Function(e) e.product) _
            .WithRequired(Function(e) e.category) _
            .WillCascadeOnDelete(True)
        modelBuilder.Entity(Of AspNetRoles)() _
            .HasMany(Function(e) e.AspNetUserRoles) _
            .WithRequired(Function(e) e.AspNetRoles) _
            .HasForeignKey(Function(e) e.RoleId)

    End Sub
End Class
