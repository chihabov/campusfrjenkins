Feature: Création du compte campus france 



@mytag
Scenario: Creer Un Nouveau Compte Sur Campus France
    Given L'utilisateur se trouve sur la page daccueil de Campus France
    When  L'utilisateur renseigne "<email>" , "<Motdepass>" , "<confMotPasse>" 
    And L'utilisateur clique sur le bouton "Mme"  
    And L'utilisateur renseigne les champs "<Nom>","<Prénom>"
    And L'utilisateur séléctionne "Afrique", "<PaysdeNationalité>"
    And L'utilisateur remplie "<Codepostal>", "<Ville>", "<Telephone>"
    And L'utilisateur Clique sur le bouton Etudiants "Etudiants"
    And L'utilisateur séléctionne le domaine "Biologie"
    And L'utilisateur séléctionne le niveau "Licence 1"
    And L'utillisateur clique sur "accepter"
    Then afficher le message

Scenario: Creer Un Nouveau Compte Sur Campus France pour institutionnel
    Given L'Utilisateur se trouve sur la page daccueil de Campus France
    When  L'Utilisateur renseigne "<email>" , "<Motdepass>" , "<confMotPasse>" 
    And L'Utilisateur clique sur le bouton "Mme"  
    And L'Utilisateur renseigne les champs "<Nom>","<Prénom>"
    And L'Utilisateur séléctionne "Afrique", "<PaysdeNationalité>"
    And L'Utilisateur remplie "<Codepostal>", "<Ville>", "<Telephone>"
    And L'Utilisateur Clique sur le bouton Etudiants "Institutionnel"
    And L'utilisateur renseigne la fonction "<Fonction>"
    And L'Utilisateur séléctione le niveau "Type d'organisme"
    And L'utilisateur renseigne le nom de lorganisme "<NomdeLorganisation>"
    And L'Utillisateur clique sur "accepter"
    Then afficher les messagess
 
    