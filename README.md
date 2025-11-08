# Âmbito do Projeto

O presente trabalho prático da unidade curricular **Arquiteturas e Integração de Sistemas** tem como objetivo conceber e implementar uma solução baseada em **microserviços** para a gestão interna de consultas numa **Unidade de Cuidados Continuados Integrados (UCCI)**.

Atualmente, a UCCI recebe da **Unidade Local de Saúde (ULS)** as marcações de consultas dos seus utentes através de comunicações em formato físico (cartas). Após a receção destas, os funcionários registam manualmente os dados das consultas, verificam possíveis sobreposições de horários e comunicam internamente a necessidade de acompanhamento dos utentes. Este processo é lento, suscetível a erros e altamente dependente de verificações manuais, o que gera **ineficiências operacionais** e dificulta o **planeamento diário** da instituição.

O sistema proposto tem como propósito **modernizar e automatizar** o processo interno de gestão de consultas, centralizando o registo e acompanhamento das marcações recebidas da ULS. Assim, todo o controlo e atualização das informações passam a ocorrer de forma **digital e integrada**, eliminando a necessidade de documentação física e reduzindo significativamente a **probabilidade de erro humano**.

A solução seguirá um modelo arquitetural baseado em **microserviços**, garantindo **escalabilidade, modularidade e fácil manutenção**:  

- **Serviço de Consultas**: responsável pelo registo, atualização e visualização de consultas.  
- **Serviço de Utentes**: mantém os dados essenciais dos pacientes e respetivos responsáveis.  
- **Serviço de Funcionários**: gere os funcionários e verifica a associação às consultas, se necessário.  

Cada microserviço será disponibilizado através de uma **API RESTful**, documentada com **OpenAPI**, e será isolado em **containers Docker**, permitindo posterior orquestração com **Kubernetes**. O sistema será desenvolvido com foco em **segurança, integração e automação**, incorporando **testes unitários e de integração** e uma **pipeline CI/CD** com **GitHub Actions** para facilitar o deployment em ambiente cloud (Azure).

Com esta abordagem, a UCCI passará a dispor de um sistema interno mais **estruturado, eficiente e confiável**, que agiliza a gestão das consultas e otimiza a **comunicação interna entre os colaboradores**, contribuindo para uma melhor coordenação e qualidade do serviço prestado aos utentes.


# Identificação dos Atores

Nesta secção são identificados e descritos os principais atores que interagem com o sistema proposto. Cada ator desempenha um papel específico no processo de gestão de consultas, com permissões e responsabilidades distintas.  
A definição clara destes perfis permite estabelecer fronteiras de acesso e garantir a **segurança** e **integridade** das informações trocadas entre os microserviços.

## 2.1. Administrador

O **Administrador** é o utilizador com o nível de acesso mais elevado dentro do sistema. É responsável pela configuração inicial e pela manutenção das entidades principais, como funcionários e perfis de acesso.  

Pode criar, editar ou eliminar registos em qualquer um dos microserviços (Consultas, Utentes e Funcionários), além de gerir permissões de acesso e definir parâmetros de funcionamento do sistema.  

**Principais responsabilidades:**
- Gerir contas de utilizadores (criação, ativação e remoção);
- Configurar parâmetros gerais do sistema;
- Aceder a todas as informações de consultas, utentes e funcionários;
- Supervisionar a comunicação entre microserviços e a integração com sistemas externos.

## 2.2. Funcionário

O **Funcionário** é o principal utilizador operacional do sistema. É responsável pelo registo, atualização e acompanhamento das consultas dos utentes da UCCI.  

Após a receção das marcações enviadas pela Unidade Local de Saúde (ULS), o funcionário introduz os dados no sistema, verifica sobreposições de horários e comunica internamente as necessidades de acompanhamento.

**Principais responsabilidades:**
- Registar novas consultas e atualizar informações existentes;
- Associar consultas aos respetivos utentes e funcionários responsáveis;
- Consultar o histórico e o estado atual das marcações;
- Gerir a comunicação com outros intervenientes internos da UCCI.

## 2.3. Gestor Clínico

O **Gestor Clínico** supervisiona a agenda geral de consultas e garante que não existem conflitos de horários ou falhas no planeamento.  

Possui permissões intermédias — superiores às do funcionário, mas inferiores às do administrador — permitindo-lhe realizar alterações de gestão sem comprometer a configuração técnica do sistema.

**Principais responsabilidades:**
- Visualizar e gerir o planeamento diário e semanal das consultas;
- Detetar e resolver conflitos de marcações;
- Gerar relatórios de desempenho e indicadores de eficiência;
- Acompanhar a utilização do sistema pelos funcionários.

## 2.4. Unidade Local de Saúde (ULS) – Sistema Externo

A **ULS** representa o sistema externo responsável pelo envio das marcações de consultas para a UCCI.  

Este ator não interage diretamente com a interface de utilizador, mas sim através de uma integração via API externa, que permite o envio automatizado dos dados das marcações.

**Principais responsabilidades:**
- Enviar automaticamente as marcações de consultas para o microserviço de Consultas;
- Garantir a consistência e integridade dos dados transmitidos;
- Permitir a comunicação segura entre sistemas distintos através de APIs RESTful.

## 2.5. Utente

O **Utente** é o destinatário final dos serviços prestados pela UCCI. Embora a sua interação com o sistema seja indireta, numa versão futura poderá aceder ao estado das suas consultas através de um portal ou aplicação móvel.  

Nesta fase do projeto, o utente é principalmente uma entidade gerida internamente pelo microserviço de Utentes.

**Principais responsabilidades:**
- Ser associado a uma ou mais consultas registadas no sistema;
- Permitir a gestão dos seus dados clínicos e administrativos básicos;
- Consultar, futuramente, o estado e histórico das suas consultas.

## 2.6. Síntese dos Atores e Níveis de Acesso

| Ator                | Descrição                              | Permissões Principais                       |
|--------------------|----------------------------------------|--------------------------------------------|
| Administrador       | Gere o sistema e configurações globais | Acesso total a todos os microserviços      |
| Gestor Clínico      | Supervisiona planeamento e relatórios  | Visualizar e editar consultas e dados de utentes |
| Funcionário         | Regista e atualiza consultas e associa utentes | Criar, editar e consultar dados de consultas e utentes |
| ULS (Sistema Externo) | Sistema que envia marcações à UCCI   | Inserção automática de consultas via API   |
| Utente              | Paciente acompanhado pela UCCI         | SEM ACESSO                                 |

## 2.7. Interação entre Atores e Microserviços

Cada ator interage com um conjunto definido de microserviços, respeitando o princípio de **menor privilégio**:

- **Administrador**: acesso completo aos microserviços de Consultas, Utentes e Funcionários.  
- **Funcionário**: interage principalmente com os serviços de Consultas e Utentes.  
- **Gestor Clínico**: consome dados agregados de todos os microserviços, com foco em relatórios e planeamento.  
- **Sistema Externo (ULS)**: comunica apenas com o microserviço de Consultas, através de endpoints seguros.  
- **Utente**: interage de forma indireta, sendo representado como entidade dentro do microserviço de Utentes.  

# 3. Processo de Negócio

## 3.1. Descrição Geral

O processo de negócio da UCCI tem como objetivo agilizar a gestão interna das consultas dos utentes, substituindo os registos manuais em papel por um sistema digital centralizado e integrado.

Atualmente, a UCCI recebe cartas enviadas pela ULS contendo as marcações de consultas. O processamento destas informações é totalmente manual, originando erros, sobreposições de horários e atrasos na comunicação interna.  

O sistema proposto visa **automatizar e digitalizar** este processo, permitindo que os funcionários registem as consultas, associem os utentes e planeiem a agenda de forma mais eficiente.

**Fluxo do processo:**
1. **Receção da carta com marcações da ULS**  
   - O funcionário da UCCI recebe fisicamente a carta com as informações da consulta (data, hora, médico, utente, etc.).

2. **Registo no sistema digital**  
   - O funcionário insere os dados da consulta no microserviço de Consultas.  
   - Caso o utente ainda não exista, é criado um novo registo no microserviço de Utentes.

3. **Verificação de disponibilidade e conflitos**  
   - O sistema ou funcionário verifica se já existe alguma consulta marcada para o mesmo horário.  
   - Conflitos são resolvidos manualmente, se necessário.

4. **Atribuição de responsável interno**  
   - Um funcionário é designado como responsável pela consulta e associado ao utente e marcação através do microserviço de Funcionários.

5. **Acompanhamento e atualização do estado da consulta**  
   - Atualização do estado da consulta (realizada, cancelada, reagendada) e observações internas.

6. **Visualização e relatórios de gestão**  
   - Gestor clínico e administrador consultam o planeamento e geram relatórios sobre volume de atendimentos, tempos médios e ocupação.

## 3.2. BPMN

![Diagrama BPMN](https://raw.githubusercontent.com/Goncalo04Costa/MEI-Arquiteturas-e-Integra-o-de-Sistemas-UCCI-System/main/BPMN.png)



## 3.3. Benefícios do Processo Digitalizado

- Eliminação do uso de papel e simplificação do fluxo administrativo;
- Redução significativa de erros de registo e sobreposições de horários;
- Melhoria da coordenação entre funcionários e gestores;
- Acesso rápido a históricos e relatórios de desempenho;
- Aumento da eficiência e fiabilidade da informação interna.

## 3.4. Síntese dos Microserviços Envolvidos

| Microserviço   | Função Principal                                   | Atores Envolvidos                    |
|----------------|---------------------------------------------------|-------------------------------------|
| Consultas      | Regista, atualiza e gere as marcações           | Funcionário, Gestor Clínico, Administrador |
| Utentes        | Mantém os dados dos utentes e respetivos responsáveis | Funcionário, Administrador         |
| Funcionários   | Garante a gestão interna dos profissionais e associações às consultas | Administrador, Gestor Clínico |
