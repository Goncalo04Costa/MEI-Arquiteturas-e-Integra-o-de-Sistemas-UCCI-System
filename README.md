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
