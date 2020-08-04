////////////////StatusLeito/////////////////////////////////////
db.getCollection('StatusPedidoInternacao').insertMany([{'Descricao':'Aberto', 'CodigoStatus':1},
                                                       {'Descricao':'Em atendimento', 'CodigoStatus':2},
                                                       {'Descricao':'Concluído', 'CodigoStatus':3},
                                            ]);
                                            
////////////////StatusLeito/////////////////////////////////////
db.getCollection('StatusLeito').insertMany([{'Descricao':'Ocupado', 'CodigoStatus':1},
                                            {'Descricao':'Vago', 'CodigoStatus':2},
                                            {'Descricao':'Reservado', 'CodigoStatus':3},
                                            ]);
                        
////////////////TipoLeitos/////////////////////////////////////
db.getCollection('TipoLeito').insertMany([{'Descricao':'Leito Clínico', 'CodigoLeito':1},
                        {'Descricao':'Leito Cirúrgico', 'CodigoLeito':2},
                        {'Descricao':'Leito Obstétrico', 'CodigoLeito':3},
                        {'Descricao':'Leito Pediátrico', 'CodigoLeito':4},
                        {'Descricao':'Leito de Isolamento', 'CodigoLeito':5},
                        {'Descricao':'Leito de Isolamento Reverso', 'CodigoLeito':6},
                        {'Descricao':'Leito de Cuidados Intensivos (UTI)', 'CodigoLeito':7},
                        {'Descricao':'Leito de Cuidados Intermediários (UCI)', 'CodigoLeito':8},
                        {'Descricao':'Leito de Recuperação Pós-Anestésica (RPA)', 'CodigoLeito':9},
                        {'Descricao':'Leito de Apoio para Procedimentos Diagnósticos e/ou Terapêuticos', 'CodigoLeito':10},
                        {'Descricao':'Leito de Urgência e Emergência', 'CodigoLeito':11},
                        {'Descricao':'Leito de Pré-Parto', 'CodigoLeito':12}
                       ]);
////////////////TipoExames/////////////////////////////////////
db.getCollection('TipoExame').insertMany([{'Descricao':'Hemograma', 'CodigoExame':1},
                        {'Descricao':'Colesterol', 'CodigoExame':2},
                        {'Descricao':'Ureia e Creatinina', 'CodigoExame':3},
                        {'Descricao':'Papanicolau', 'CodigoExame':4},
                        {'Descricao':'Exames de urina', 'CodigoExame':5},
                        {'Descricao':'Exames de fezes', 'CodigoExame':6},
                        {'Descricao':'Glicemia', 'CodigoExame':7},
                        {'Descricao':'Transaminases (ALT e AST) ou TGP e TGO', 'CodigoExame':8},
                        {'Descricao':'TSH e T4 livre', 'CodigoExame':9},
                        {'Descricao':'Triglicerídeos', 'CodigoExame':10},
                        {'Descricao':'Ácido úrico', 'CodigoExame':11},
                        {'Descricao':'Radiografia convencional (Raio-x)', 'CodigoExame':12},
                        {'Descricao':'Mamografia', 'CodigoExame':13},
                        {'Descricao':'Densitometria óssea', 'CodigoExame':14},
                        {'Descricao':'Tomografia computadorizada', 'CodigoExame':15},
                        {'Descricao':'Ressonância magnética', 'CodigoExame':16},
                        {'Descricao':'Ultrassonografia', 'CodigoExame':17},
                        {'Descricao':'Medicina nuclear', 'CodigoExame':18},
                        {'Descricao':'Angiografia', 'CodigoExame':19}
                       ]);
////////////////ESPECIALIDADES/////////////////////////////////////
db.getCollection('Especialidade').insertMany([{'Descricao':'Acupuntura', 'CodigoEspecialidade':1},
                           {'Descricao':'Alergia e Imunologia', 'CodigoEspecialidade':2},
                           {'Descricao':'Anestesiologia', 'CodigoEspecialidade':3},
                           {'Descricao':'Angiologia e Cirurgia Vascular', 'CodigoEspecialidade':4},
                           {'Descricao':'Cardiologia', 'CodigoEspecialidade':5},
                           {'Descricao':'Cirurgia Cardiovascular', 'CodigoEspecialidade':6},
                           {'Descricao':'Cirurgia da Mao', 'CodigoEspecialidade':7},
                           {'Descricao':'Cirurgia de Cabeca e Pescoco', 'CodigoEspecialidade':8},
                           {'Descricao':'Cirurgia Geral', 'CodigoEspecialidade':9},
                           {'Descricao':'Cirurgia Pediatrica', 'CodigoEspecialidade':10},
                           {'Descricao':'Cirurgia Plastica', 'CodigoEspecialidade':11},
                           {'Descricao':'Cirurgia Toracica', 'CodigoEspecialidade':12},
                           {'Descricao':'Clinica Medica', 'CodigoEspecialidade':13},
                           {'Descricao':'Coloproctologia', 'CodigoEspecialidade':14},
                           {'Descricao':'Dermatologia', 'CodigoEspecialidade':15},
                           {'Descricao':'Dor', 'CodigoEspecialidade':16},
                           {'Descricao':'Endocrinologia e Metabologia', 'CodigoEspecialidade':17},
                           {'Descricao':'Endoscopia', 'CodigoEspecialidade':18},
                           {'Descricao':'Gastroenterologia', 'CodigoEspecialidade':19},
                           {'Descricao':'Genetica Medica', 'CodigoEspecialidade':20},
                           {'Descricao':'Geriatria', 'CodigoEspecialidade':21},
                           {'Descricao':'Ginecologia e Obstetricia', 'CodigoEspecialidade':22},
                           {'Descricao':'Hematologia e Hemoterapia', 'CodigoEspecialidade':23},
                           {'Descricao':'Homeopatia', 'CodigoEspecialidade':24},
                           {'Descricao':'Infectologia', 'CodigoEspecialidade':25},
                           {'Descricao':'Mastologia', 'CodigoEspecialidade':26},
                           {'Descricao':'Nefrologia', 'CodigoEspecialidade':27},
                           {'Descricao':'Neurologia', 'CodigoEspecialidade':28},
                           {'Descricao':'Nutrologia', 'CodigoEspecialidade':29},
                           {'Descricao':'Oftalmologia', 'CodigoEspecialidade':30},
                           {'Descricao':'Ortopedia e Traumatologia', 'CodigoEspecialidade':31},
                           {'Descricao':'Otorrinolaringologia', 'CodigoEspecialidade':32},
                           {'Descricao':'Patologia', 'CodigoEspecialidade':33},
                           {'Descricao':'Pediatria', 'CodigoEspecialidade':34},
                           {'Descricao':'Pneumologia', 'CodigoEspecialidade':35},
                           {'Descricao':'Reumatologia', 'CodigoEspecialidade':36},
                           {'Descricao':'Sexologia', 'CodigoEspecialidade':37},
                           {'Descricao':'Urologia', 'CodigoEspecialidade':38}                           
                          ]);
                           
////////////////PERFIS/////////////////////////////////////
db.getCollection('Perfil').insertMany([{'Descricao':'Administrador', 'CodigoPerfil' :1},
{'Descricao':'Atendente', 'CodigoPerfil' :2},
{'Descricao':'UsuarioSUS', 'CodigoPerfil' :3}]);

////////////////HORARIOS/////////////////////////////////////

var horarios = db.getCollection('Horario');
var horaInicial = '08:00'
var i = 1;

while(Number(horaInicial.split(':')[0]) < 20){
     
    var intHoraInicial = Number(horaInicial.split(':')[0]);
    var intMinutoInicial = Number(horaInicial.split(':')[1]);
        
    var horaFinal =  (intMinutoInicial > 0 ? (intHoraInicial+1).toString() : intHoraInicial.toString()) + ':' + 
                     (intMinutoInicial > 0 ? '00' : '30');
           
    horarios.insert({
                        'CodigoHorario': i,
                        'HoraInicial': "'" + horaInicial + "'", 
                        'HoraFinal': "'" + horaFinal + "'"
                    });  
   
    i++;
    horaInicial = horaFinal;                 
}

////////////////Medicos/////////////////////////////////////
var medicos = db.getCollection('Medico');
var especialidades = db.getCollection('Especialidade').find();
var codigoMedico = 1;

especialidades.forEach(function(esp){
    
    for(i=1;i<=3;i++){
        medicos.insert({'CodigoMedico': codigoMedico,
                        'Nome': 'Médico ' + codigoMedico,
                        'CRM': 'CRM' + codigoMedico,
                        'CodigoEspecialidade': esp.CodigoEspecialidade}
                      );
                        
        codigoMedico++;
    }       
});


