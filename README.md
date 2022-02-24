Rest API that allows you to perform crud operations on credit card and account for bank customers.

Project has Docker, and swagger implimentaion.

Models
- Account
 - Account id: id of the account
 - Iban: iban of the account
 - bank Code: bank Code of the account
 - Customer id: client to whom the account belongs 
- Card
 - Card id: the id of the card (not editable)
 - Card alias: personalised name of the card (editable)
 - Account id: account to which the card belongs (not editable)
 - Type of card: indicates if a card is virtual or physical (not editable)
