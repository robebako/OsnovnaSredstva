# Osnovna Sredstva
je jednostavna aplikacija za evidenciju osnovih sredstava. Ona koristi Identity za prijavu korisnika i Entity Framework za upravljanje bazom podataka.
Anonimni korisnici mogu pregledavati listu osnovnih sredstava, dok samo registrirani i prijavljeni korisnici mogu dodavati, uređivati i brisati stavke 
osnovnih sredstava i pripadajućih grupa. Za registraciju korisnika je potrebna e-mail adresa i lozinka koja nema nikakvih ograničenja osim minimalne duljine od 4 znaka.
Kod prikaza popisa osnovnih sredstava, sortiranje po određenim kolonama je izvedeno pomoću LINQ upita.
