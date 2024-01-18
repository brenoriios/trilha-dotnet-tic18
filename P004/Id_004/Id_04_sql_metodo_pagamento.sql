CREATE TABLE `osmanagerdb`.`metodo_pagamento` (
    `metodo_pagamento_id` INT NOT NULL AUTO_INCREMENT,
    `nome` VARCHAR(100) NOT NULL,
    `descricao` VARCHAR(300) NOT NULL,
    `taxa` FLOAT NOT NULL,
    PRIMARY KEY (`metodo_pagamento_id`)
);
