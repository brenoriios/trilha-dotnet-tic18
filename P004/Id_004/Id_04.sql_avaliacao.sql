CREATE TABLE `osmanagerdb`.`avaliacao` (
  `avaliacao_id` INT NOT NULL AUTO_INCREMENT,
  `comentario` VARCHAR(300) NULL,
  `nota` FLOAT NOT NULL,
  `ordem_de_servico_id` INT,
  PRIMARY KEY (`avaliacao_id`)
);
