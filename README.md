# CP5-.NET

# RabbitMQ Microservices - 

### Membros do Grupo
- **Enzo Franco Rocha** - RM: 553643
- **João Pedro Pereira** - RM: 553698
- **Herbert Santos de Sousa** - RM: 553227

Este projeto implementa uma arquitetura simples de microserviços usando RabbitMQ. São criados dois fluxos principais (Frutas e Usuários), com envio, validação e consumo final das mensagens.

## 🗂 Estrutura do Projeto

| Projeto     | Descrição                                                                 |
|-------------|---------------------------------------------------------------------------|
| **SenderFruta** | Envia informações sobre frutas.                                           |
| **SenderUsuario** | Envia informações sobre usuários.                                         |
| **ValidationFruta** | Consome as mensagens do SenderFruta, valida os dados e envia para os Receivers. |
| **ValidationUsuario** | Consome as mensagens do SenderUsuario, valida os dados e envia para os Receivers. |
| **ReceiverFruta** | Consome frutas validadas.                                                |
| **ReceiverUsuario** | Consome usuários validados.                                              |

## 🔗 Fluxo de Mensagens

**Sender1** → `fruit.exchange` (routing: `fruit.validation`)

 **Sender2** → `user.exchange` (routing: `user.validation`)

 **Validation**:
   - Consome da fila `fruit.validation` e publica em `fruit.validated`.
   - Consome da fila `user.validation` e publica em `user.validated`.

 **Receiver1** e **Receiver2**: Consomem as mensagens validadas.

## Dependências

- `RabbitMQ.Client`


