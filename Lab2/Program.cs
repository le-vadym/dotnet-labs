using Lab2.Data;
using Lab2.Models;

var dbContextFactory = new LibraryDbContextFactory();
var context = dbContextFactory.CreateDbContext();
