# Auction website


A mvc application using the ASP.Net framework

deltagare: Emil Wennström, Algot von Reybekiel
emilwen@kth.se, algotvr@kth.se


Instructions for adding relevant databases in Visual Studio:
Open Tools> NuGet Package Manager > Package Manager Console


Add Auction-database:

Add-Migration Initial -Context AuctionDbContext

Update-Database -Context AuctionDbContext


Add Identity-database:

Add-Migration Initial -Context IdentityContext  

Update-Database -Context IdentityContext
