# Documentação da API EnzoKey

---

## 🔐 Autenticação

### [POST] /api/auth/login  
**Descrição:** Realiza login do usuário interno e retorna token JWT.  
**Entrada:**  
```json
{
  "email": "admin@enzosoft.com",
  "senha": "*******"
}
```  
**Saída:**  
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

## 👥 Clientes

### [GET] /api/clientes  
Lista todos os clientes.

### [GET] /api/clientes/{id}  
Busca um cliente específico.

### [POST] /api/clientes  
Cadastra um novo cliente.

### [PUT] /api/clientes/{id}  
Atualiza um cliente.

### [DELETE] /api/clientes/{id}  
Remove um cliente.

---

## 📦 Produtos / Softwares

### [GET] /api/produtos  
Lista todos os produtos.

### [GET] /api/produtos/{id}  
Busca um produto específico.

### [POST] /api/produtos  
Cadastra um novo produto/software.

### [PUT] /api/produtos/{id}  
Atualiza um produto.

### [DELETE] /api/produtos/{id}  
Remove um produto.

---

## 🧾 Tipos de Licenciamento

### [GET] /api/tipos-licenca  
Lista todos os tipos de licenças disponíveis.

---

## 🔑 Licenças (Produtos Licenciados)

### [GET] /api/licencas  
Lista todas as licenças.

### [GET] /api/licencas/{id}  
Busca uma licença específica.

### [POST] /api/licencas  
Emite uma nova licença (cliente + produto + tipo).

### [PUT] /api/licencas/{id}  
Atualiza dados da licença (status, validade).

### [DELETE] /api/licencas/{id}  
Revoga uma licença (marcar como inativa/suspensa).

---

## 🛡️ API Pública de Validação de Licença

### [POST] /api/licenca/validar  
**Descrição:** Verifica se a chave da licença informada é válida.

**Entrada:**
```json
{
  "chaveLicenca": "ENZ-123-XYZ"
}
```

**Saída:**
```json
{
  "valida": true,
  "status": "Ativa",
  "cliente": {
    "nome": "Empresa XYZ",
    "email": "contato@empresa.com"
  },
  "produto": {
    "nome": "Meu Software",
    "versao": "2.1"
  },
  "tipoLicenca": "Tempo Determinado",
  "expiraEm": "2025-12-31T23:59:59"
}
```

---

### [GET] /api/licenca/dados-cliente/{chaveLicenca}  
**Descrição:** Retorna os dados do cliente e produto vinculados a uma chave de licença válida.

---

## 🔒 Segurança

- Todas as rotas (exceto `/licenca/validar` e `/licenca/dados-cliente`) exigem autenticação JWT.
- A API deve ser consumida via HTTPS.
- Tokens JWT devem ser enviados no header:  
  `Authorization: Bearer {token}`

---

# Fim do Documento