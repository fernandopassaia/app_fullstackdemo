// using System;

// namespace AppFullStackDemo.Domain.Entities.Security
// {
//     // I'll Store the Currently Token of the User - so the Active Token will be stored. Just the Currently.
//     // When the Token Expires, the Process of "RefreshToken" will delete the Old-Expired Token and Replaces by New-One.
//     public class Token
//     {
//         public Token(User user, DateTime dateOfExpiration, string tokenKey)
//         {
//             User = user;
//             DateOfExpiration = dateOfExpiration;
//             TokenKey = tokenKey;
//         }

//         protected Token()
//         {
//         }

//         public bool Active { get; private set; }

//         public DateTime DateOfExpiration { get; private set; }

//         public User User { get; private set; }

//         public Guid Id { get; private set; } = new Guid();

//         public string TokenKey { get; private set; }
//     }
// }