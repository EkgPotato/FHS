using Microsoft.EntityFrameworkCore;

namespace DataService.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options);