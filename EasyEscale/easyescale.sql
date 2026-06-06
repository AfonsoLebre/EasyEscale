/*
 Navicat Premium Data Transfer

 Source Server         : PAP
 Source Server Type    : MySQL
 Source Server Version : 80046 (8.0.46)
 Source Host           : localhost:3306
 Source Schema         : easyescale

 Target Server Type    : MySQL
 Target Server Version : 80046 (8.0.46)
 File Encoding         : 65001

 Date: 22/05/2026 11:06:43
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for aulas
-- ----------------------------
DROP TABLE IF EXISTS `aulas`;
CREATE TABLE `aulas`  (
  `IdAula` int NOT NULL AUTO_INCREMENT,
  `IdProfessor` int NULL DEFAULT NULL,
  `HoraInicial` enum('8:25','9:10','10:10','10:55','11:50','12:35','13:35','14:20','15:15','16:00','16:55','17:40') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `HoraFinal` enum('9:10','9:55','10:55','11:40','12:35','13:20','14:20','15:05','16:00','16:45','17:40','18:25') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Dia_Semana` enum('Segunda-Feira','Terca-Feira','Quarta-Feira','Quinta-Feira','Sexta-Feira') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IdDisciplina` int NULL DEFAULT NULL,
  `IdTurma` int NULL DEFAULT NULL,
  PRIMARY KEY (`IdAula`) USING BTREE,
  INDEX `IdProfessor`(`IdProfessor` ASC) USING BTREE,
  INDEX `IdDisciplina`(`IdDisciplina` ASC) USING BTREE,
  INDEX `IdTurma`(`IdTurma` ASC) USING BTREE,
  CONSTRAINT `aulas_ibfk_1` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `aulas_ibfk_2` FOREIGN KEY (`IdDisciplina`) REFERENCES `disciplina` (`IdDisciplina`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `aulas_ibfk_3` FOREIGN KEY (`IdTurma`) REFERENCES `turmas` (`IdTurma`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 8545 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aulas
-- ----------------------------
INSERT INTO `aulas` VALUES (8533, 1, '8:25', '9:10', 'Segunda-Feira', 1, 1);
INSERT INTO `aulas` VALUES (8534, 2, '9:10', '9:55', 'Segunda-Feira', 2, 1);
INSERT INTO `aulas` VALUES (8535, 3, '10:10', '10:55', 'Segunda-Feira', 3, 1);
INSERT INTO `aulas` VALUES (8536, 1, '10:55', '11:40', 'Segunda-Feira', 1, 1);
INSERT INTO `aulas` VALUES (8537, 4, '8:25', '9:10', 'Terca-Feira', 4, 1);
INSERT INTO `aulas` VALUES (8538, 5, '10:10', '10:55', 'Terca-Feira', 5, 1);
INSERT INTO `aulas` VALUES (8539, 6, '11:50', '12:35', 'Terca-Feira', 1, 2);
INSERT INTO `aulas` VALUES (8540, 7, '13:35', '14:20', 'Quarta-Feira', 2, 2);
INSERT INTO `aulas` VALUES (8541, 8, '14:20', '15:05', 'Quarta-Feira', 3, 2);
INSERT INTO `aulas` VALUES (8542, 16, '8:25', '9:10', 'Segunda-Feira', 1, 4);
INSERT INTO `aulas` VALUES (8543, 17, '9:10', '9:55', 'Segunda-Feira', 2, 4);
INSERT INTO `aulas` VALUES (8544, 18, '10:10', '10:55', 'Segunda-Feira', 3, 4);

-- ----------------------------
-- Table structure for disciplina
-- ----------------------------
DROP TABLE IF EXISTS `disciplina`;
CREATE TABLE `disciplina`  (
  `IdDisciplina` int NOT NULL AUTO_INCREMENT,
  `Curso` enum('Profissional','CientificoHumanistico') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Designacao` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`IdDisciplina`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of disciplina
-- ----------------------------
INSERT INTO `disciplina` VALUES (1, 'CientificoHumanistico', 'Matemática A');
INSERT INTO `disciplina` VALUES (2, 'CientificoHumanistico', 'Portugues');
INSERT INTO `disciplina` VALUES (3, 'CientificoHumanistico', 'Matematica');
INSERT INTO `disciplina` VALUES (4, 'CientificoHumanistico', 'Português');
INSERT INTO `disciplina` VALUES (5, 'CientificoHumanistico', 'Fisica');
INSERT INTO `disciplina` VALUES (6, 'CientificoHumanistico', 'Quimica');
INSERT INTO `disciplina` VALUES (7, 'CientificoHumanistico', 'Biologia');
INSERT INTO `disciplina` VALUES (8, 'Profissional', 'Programação');
INSERT INTO `disciplina` VALUES (9, 'Profissional', 'Redes');
INSERT INTO `disciplina` VALUES (10, 'Profissional', 'Base de Dados');
INSERT INTO `disciplina` VALUES (11, 'Profissional', 'Matematica');
INSERT INTO `disciplina` VALUES (12, 'Profissional', 'Fisica');
INSERT INTO `disciplina` VALUES (13, 'CientificoHumanistico', 'Quimica');
INSERT INTO `disciplina` VALUES (14, 'CientificoHumanistico', 'Biologia');

-- ----------------------------
-- Table structure for disciprofessor
-- ----------------------------
DROP TABLE IF EXISTS `disciprofessor`;
CREATE TABLE `disciprofessor`  (
  `IdDiscirofessor` int NOT NULL AUTO_INCREMENT,
  `IdProfessor` int NULL DEFAULT NULL,
  `IdDisciplina` int NULL DEFAULT NULL,
  `AnoEscolar` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`IdDiscirofessor`) USING BTREE,
  INDEX `IdProfessor`(`IdProfessor` ASC) USING BTREE,
  INDEX `IdDisciplina`(`IdDisciplina` ASC) USING BTREE,
  CONSTRAINT `disciprofessor_ibfk_1` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `disciprofessor_ibfk_2` FOREIGN KEY (`IdDisciplina`) REFERENCES `disciplina` (`IdDisciplina`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of disciprofessor
-- ----------------------------
INSERT INTO `disciprofessor` VALUES (4, 2, 2, '10');

-- ----------------------------
-- Table structure for exames
-- ----------------------------
DROP TABLE IF EXISTS `exames`;
CREATE TABLE `exames`  (
  `IdExame` int NOT NULL AUTO_INCREMENT,
  `Data` date NULL DEFAULT NULL,
  `HoraInicial` enum('8:00','8:30','9:00','9:30','10:00','10:30','11:00','13:00','13:30','14:00','14:30','15:00') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `HoraFinal` enum('10:00','10:30','11:00','11:30','12:00','12:30','13:00','15:00','15:30','16:00','16:30','17:00') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IdDisciplina` int NULL DEFAULT NULL,
  `CodExame` int NULL DEFAULT NULL,
  `ES` bit(1) NULL DEFAULT b'0',
  PRIMARY KEY (`IdExame`) USING BTREE,
  INDEX `IdDisciplina`(`IdDisciplina` ASC) USING BTREE,
  CONSTRAINT `exames_ibfk_1` FOREIGN KEY (`IdDisciplina`) REFERENCES `disciplina` (`IdDisciplina`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 111 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of exames
-- ----------------------------
INSERT INTO `exames` VALUES (100, '2025-06-30', '9:00', '12:00', 1, 639, b'0');
INSERT INTO `exames` VALUES (101, '2025-07-02', '13:00', '15:30', 2, 714, b'0');
INSERT INTO `exames` VALUES (108, '2026-07-10', '9:00', '12:00', 1, 888, b'1');
INSERT INTO `exames` VALUES (109, '2026-07-12', '10:00', '12:00', 2, 889, b'1');
INSERT INTO `exames` VALUES (110, '2026-05-22', '8:00', '11:00', 3, 222, b'0');

-- ----------------------------
-- Table structure for professor
-- ----------------------------
DROP TABLE IF EXISTS `professor`;
CREATE TABLE `professor`  (
  `IdProfessor` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `NProcesso` int NULL DEFAULT NULL,
  PRIMARY KEY (`IdProfessor`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 51 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of professor
-- ----------------------------
INSERT INTO `professor` VALUES (1, 'Carlos Mendes', 'carlos@escola.pt', 11101);
INSERT INTO `professor` VALUES (2, 'Ana Rita Silva', 'ana@escola.pt', 11102);
INSERT INTO `professor` VALUES (3, 'Paulo Jorge', 'paulo@escola.pt', 11103);
INSERT INTO `professor` VALUES (4, 'Ricardo Pereira', 'ricardo@escola.pt', 11104);
INSERT INTO `professor` VALUES (5, 'Sofia Santos', 'sofia@escola.pt', 11105);
INSERT INTO `professor` VALUES (6, 'Marta Oliveira', 'marta@escola.pt', 11106);
INSERT INTO `professor` VALUES (7, 'Joao Ferreira', 'joao@escola.pt', 11107);
INSERT INTO `professor` VALUES (8, 'Beatriz Costa', 'beatriz@escola.pt', 11108);
INSERT INTO `professor` VALUES (9, 'Nuno Almeida', 'nuno@escola.pt', 11109);
INSERT INTO `professor` VALUES (10, 'Luisa Martins', 'luisa@escola.pt', 11110);
INSERT INTO `professor` VALUES (11, 'Tiago Rodrigues', 'tiago@escola.pt', 11111);
INSERT INTO `professor` VALUES (12, 'Ines Ferreira', 'ines@escola.pt', 11112);
INSERT INTO `professor` VALUES (13, 'Pedro Silva', 'pedro@escola.pt', 11113);
INSERT INTO `professor` VALUES (14, 'Helena Gomes', 'helena@escola.pt', 11114);
INSERT INTO `professor` VALUES (15, 'Jose Carvalho', 'jose@escola.pt', 11115);
INSERT INTO `professor` VALUES (16, 'Maria Jose', 'maria@escola.pt', 11116);
INSERT INTO `professor` VALUES (17, 'Antonio Braganca', 'antonio@escola.pt', 11117);
INSERT INTO `professor` VALUES (18, 'Carla Filipa', 'carla@escola.pt', 11118);
INSERT INTO `professor` VALUES (19, 'Rui Pedro', 'rui@escola.pt', 11119);
INSERT INTO `professor` VALUES (20, 'Sonia Maria', 'sonia@escola.pt', 11120);

-- ----------------------------
-- Table structure for reuniao
-- ----------------------------
DROP TABLE IF EXISTS `reuniao`;
CREATE TABLE `reuniao`  (
  `IdReuniao` int NOT NULL,
  `IdTurma` int NULL DEFAULT NULL,
  `HoraInicial` enum('9:00','9:30','10:00','10:30','11:00','11:30','12:00','12:30','13:00','13:30','14:00','14:30','15:00','15:30','16:00','16:30','17:00','17:30','18:00','18:30','19:00') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `HoraFinal` enum('9:30','10:00','10:30','11:00','11:30','12:00','12:30','13:00','13:30','14:00','14:30','15:00','15:30','16:00','16:30','17:00','17:30','18:00','18:30','19:00','19:30','20:00') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Data` date NULL DEFAULT NULL,
  `sala` int NULL DEFAULT NULL,
  PRIMARY KEY (`IdReuniao`) USING BTREE,
  INDEX `IdTurma`(`IdTurma` ASC) USING BTREE,
  INDEX `sala`(`sala` ASC) USING BTREE,
  CONSTRAINT `reuniao_ibfk_1` FOREIGN KEY (`IdTurma`) REFERENCES `turmas` (`IdTurma`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reuniao_ibfk_2` FOREIGN KEY (`sala`) REFERENCES `salas` (`IdSala`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of reuniao
-- ----------------------------
INSERT INTO `reuniao` VALUES (1, 1, '11:00', '16:00', '2026-05-22', 11);
INSERT INTO `reuniao` VALUES (2, 38, '10:00', '11:00', '2026-05-30', 8);

-- ----------------------------
-- Table structure for reuniaoprofessor
-- ----------------------------
DROP TABLE IF EXISTS `reuniaoprofessor`;
CREATE TABLE `reuniaoprofessor`  (
  `ReuniaoProfessor` int NOT NULL AUTO_INCREMENT,
  `IdReuniao` int NULL DEFAULT NULL,
  `IdProfessor` int NULL DEFAULT NULL,
  PRIMARY KEY (`ReuniaoProfessor`) USING BTREE,
  INDEX `IdReuniao`(`IdReuniao` ASC) USING BTREE,
  INDEX `IdProfessor`(`IdProfessor` ASC) USING BTREE,
  CONSTRAINT `reuniaoprofessor_ibfk_1` FOREIGN KEY (`IdReuniao`) REFERENCES `reuniao` (`IdReuniao`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reuniaoprofessor_ibfk_2` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of reuniaoprofessor
-- ----------------------------

-- ----------------------------
-- Table structure for salas
-- ----------------------------
DROP TABLE IF EXISTS `salas`;
CREATE TABLE `salas`  (
  `IdSala` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`IdSala`) USING BTREE,
  UNIQUE INDEX `uk_nome_sala`(`Nome` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of salas
-- ----------------------------
INSERT INTO `salas` VALUES (8, 'Auditório');
INSERT INTO `salas` VALUES (5, 'Sala 10');
INSERT INTO `salas` VALUES (6, 'Sala 11');
INSERT INTO `salas` VALUES (7, 'Sala 12');
INSERT INTO `salas` VALUES (11, 'Sala 35');

-- ----------------------------
-- Table structure for turmas
-- ----------------------------
DROP TABLE IF EXISTS `turmas`;
CREATE TABLE `turmas`  (
  `IdTurma` int NOT NULL AUTO_INCREMENT,
  `Ano` int NULL DEFAULT NULL,
  `Letra` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `AnoLetivo` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`IdTurma`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 40 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of turmas
-- ----------------------------
INSERT INTO `turmas` VALUES (1, 10, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (2, 10, 'B', '2025/2026');
INSERT INTO `turmas` VALUES (3, 10, 'C', '2025/2026');
INSERT INTO `turmas` VALUES (4, 11, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (5, 11, 'B', '2025/2026');
INSERT INTO `turmas` VALUES (6, 11, 'C', '2025/2026');
INSERT INTO `turmas` VALUES (7, 12, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (8, 12, 'B', '2025/2026');
INSERT INTO `turmas` VALUES (9, 12, 'C', '2025/2026');
INSERT INTO `turmas` VALUES (10, 7, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (11, 8, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (12, 9, 'A', '2025/2026');
INSERT INTO `turmas` VALUES (37, 20, 'D', '2026/2027');
INSERT INTO `turmas` VALUES (38, 22, 'H', '2025/2026');
INSERT INTO `turmas` VALUES (39, 11, 'F', '2025/2026');

-- ----------------------------
-- Table structure for turmasprofessor
-- ----------------------------
DROP TABLE IF EXISTS `turmasprofessor`;
CREATE TABLE `turmasprofessor`  (
  `IdTurmaProfe` int NOT NULL AUTO_INCREMENT,
  `IdTurma` int NULL DEFAULT NULL,
  `IdProfessor` int NULL DEFAULT NULL,
  PRIMARY KEY (`IdTurmaProfe`) USING BTREE,
  INDEX `IdTurma`(`IdTurma` ASC) USING BTREE,
  INDEX `IdProfessor`(`IdProfessor` ASC) USING BTREE,
  CONSTRAINT `turmasprofessor_ibfk_2` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `turmasprofessor_ibfk_3` FOREIGN KEY (`IdTurma`) REFERENCES `turmas` (`IdTurma`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 432 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of turmasprofessor
-- ----------------------------
INSERT INTO `turmasprofessor` VALUES (369, 1, 1);
INSERT INTO `turmasprofessor` VALUES (370, 1, 2);
INSERT INTO `turmasprofessor` VALUES (371, 1, 3);
INSERT INTO `turmasprofessor` VALUES (372, 1, 4);
INSERT INTO `turmasprofessor` VALUES (373, 1, 5);
INSERT INTO `turmasprofessor` VALUES (374, 2, 6);
INSERT INTO `turmasprofessor` VALUES (375, 2, 7);
INSERT INTO `turmasprofessor` VALUES (376, 2, 8);
INSERT INTO `turmasprofessor` VALUES (377, 2, 9);
INSERT INTO `turmasprofessor` VALUES (378, 2, 10);
INSERT INTO `turmasprofessor` VALUES (379, 3, 11);
INSERT INTO `turmasprofessor` VALUES (380, 3, 12);
INSERT INTO `turmasprofessor` VALUES (381, 3, 13);
INSERT INTO `turmasprofessor` VALUES (382, 3, 14);
INSERT INTO `turmasprofessor` VALUES (383, 3, 15);
INSERT INTO `turmasprofessor` VALUES (384, 4, 16);
INSERT INTO `turmasprofessor` VALUES (385, 4, 17);
INSERT INTO `turmasprofessor` VALUES (386, 4, 18);
INSERT INTO `turmasprofessor` VALUES (387, 4, 19);
INSERT INTO `turmasprofessor` VALUES (388, 4, 20);
INSERT INTO `turmasprofessor` VALUES (389, 5, 1);
INSERT INTO `turmasprofessor` VALUES (390, 5, 6);
INSERT INTO `turmasprofessor` VALUES (391, 5, 11);
INSERT INTO `turmasprofessor` VALUES (392, 5, 16);
INSERT INTO `turmasprofessor` VALUES (393, 5, 2);
INSERT INTO `turmasprofessor` VALUES (394, 6, 3);
INSERT INTO `turmasprofessor` VALUES (395, 6, 8);
INSERT INTO `turmasprofessor` VALUES (396, 6, 13);
INSERT INTO `turmasprofessor` VALUES (397, 6, 18);
INSERT INTO `turmasprofessor` VALUES (398, 6, 4);
INSERT INTO `turmasprofessor` VALUES (399, 7, 5);
INSERT INTO `turmasprofessor` VALUES (400, 7, 10);
INSERT INTO `turmasprofessor` VALUES (401, 7, 15);
INSERT INTO `turmasprofessor` VALUES (402, 7, 20);
INSERT INTO `turmasprofessor` VALUES (403, 7, 7);
INSERT INTO `turmasprofessor` VALUES (404, 8, 9);
INSERT INTO `turmasprofessor` VALUES (405, 8, 14);
INSERT INTO `turmasprofessor` VALUES (406, 8, 19);
INSERT INTO `turmasprofessor` VALUES (407, 8, 1);
INSERT INTO `turmasprofessor` VALUES (408, 8, 11);
INSERT INTO `turmasprofessor` VALUES (409, 9, 2);
INSERT INTO `turmasprofessor` VALUES (410, 9, 3);
INSERT INTO `turmasprofessor` VALUES (411, 9, 4);
INSERT INTO `turmasprofessor` VALUES (412, 9, 5);
INSERT INTO `turmasprofessor` VALUES (413, 9, 6);
INSERT INTO `turmasprofessor` VALUES (414, 10, 7);
INSERT INTO `turmasprofessor` VALUES (415, 10, 8);
INSERT INTO `turmasprofessor` VALUES (416, 10, 9);
INSERT INTO `turmasprofessor` VALUES (417, 10, 10);
INSERT INTO `turmasprofessor` VALUES (418, 10, 11);
INSERT INTO `turmasprofessor` VALUES (419, 11, 12);
INSERT INTO `turmasprofessor` VALUES (420, 11, 13);
INSERT INTO `turmasprofessor` VALUES (421, 11, 14);
INSERT INTO `turmasprofessor` VALUES (422, 11, 15);
INSERT INTO `turmasprofessor` VALUES (423, 11, 16);
INSERT INTO `turmasprofessor` VALUES (424, 12, 17);
INSERT INTO `turmasprofessor` VALUES (425, 12, 18);
INSERT INTO `turmasprofessor` VALUES (426, 12, 19);
INSERT INTO `turmasprofessor` VALUES (427, 12, 20);
INSERT INTO `turmasprofessor` VALUES (428, 12, 1);
INSERT INTO `turmasprofessor` VALUES (429, 39, 2);
INSERT INTO `turmasprofessor` VALUES (430, 39, 3);
INSERT INTO `turmasprofessor` VALUES (431, 39, 4);

-- ----------------------------
-- Table structure for vigiasexames
-- ----------------------------
DROP TABLE IF EXISTS `vigiasexames`;
CREATE TABLE `vigiasexames`  (
  `IdVigia` int NOT NULL AUTO_INCREMENT,
  `IdProfessor` int NULL DEFAULT NULL,
  `IdExame` int NULL DEFAULT NULL,
  `Estado` enum('efetivo','suplente') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`IdVigia`) USING BTREE,
  INDEX `IdProfessor`(`IdProfessor` ASC) USING BTREE,
  INDEX `IdExame`(`IdExame` ASC) USING BTREE,
  CONSTRAINT `vigiasexames_ibfk_1` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `vigiasexames_ibfk_2` FOREIGN KEY (`IdExame`) REFERENCES `exames` (`IdExame`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 76 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of vigiasexames
-- ----------------------------
INSERT INTO `vigiasexames` VALUES (51, 1, 101, 'efetivo');
INSERT INTO `vigiasexames` VALUES (52, 3, 101, 'efetivo');
INSERT INTO `vigiasexames` VALUES (53, 6, 101, 'efetivo');
INSERT INTO `vigiasexames` VALUES (54, 10, 101, 'suplente');
INSERT INTO `vigiasexames` VALUES (55, 11, 101, 'suplente');
INSERT INTO `vigiasexames` VALUES (61, 2, 108, 'efetivo');
INSERT INTO `vigiasexames` VALUES (62, 4, 108, 'efetivo');
INSERT INTO `vigiasexames` VALUES (63, 5, 108, 'efetivo');
INSERT INTO `vigiasexames` VALUES (64, 7, 108, 'suplente');
INSERT INTO `vigiasexames` VALUES (65, 8, 108, 'suplente');
INSERT INTO `vigiasexames` VALUES (71, 12, 100, 'efetivo');
INSERT INTO `vigiasexames` VALUES (72, 13, 100, 'efetivo');
INSERT INTO `vigiasexames` VALUES (73, 14, 100, 'efetivo');
INSERT INTO `vigiasexames` VALUES (74, 15, 100, 'suplente');
INSERT INTO `vigiasexames` VALUES (75, 19, 100, 'suplente');

-- ----------------------------
-- Table structure for examesalas
-- ----------------------------
DROP TABLE IF EXISTS `examesalas`;
CREATE TABLE `examesalas`  (
  `IdExameSala` int NOT NULL AUTO_INCREMENT,
  `IdExame` int NULL DEFAULT NULL,
  `IdSala` int NULL DEFAULT NULL,
  PRIMARY KEY (`IdExameSala`) USING BTREE,
  INDEX `IdExame`(`IdExame` ASC) USING BTREE,
  INDEX `IdSala`(`IdSala` ASC) USING BTREE,
  CONSTRAINT `examesalas_ibfk_1` FOREIGN KEY (`IdExame`) REFERENCES `exames` (`IdExame`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `examesalas_ibfk_2` FOREIGN KEY (`IdSala`) REFERENCES `salas` (`IdSala`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

SET FOREIGN_KEY_CHECKS = 1;
