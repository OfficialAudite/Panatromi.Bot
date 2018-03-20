const Discord = require('discord.js');
const client = new Discord.Client();
const token = 'token';

client.on('ready', () => {
	console.log('I am ready!');
});

// message
client.on('message', message => {
	if (message.content === 'p!ping') {
		message.channel.send('pong');
	}
});

//bot 1
client.on('message', message => {
	if (message.content === 'p!owner') {
		message.channel.send('Well, lets see. I think my owners discord Machiko#9793. Feel free to write to him!')
	} 
});

//No swearing
client.on('message', message => {
	if (message.content === 'fuck') {
		message.channel.send('No swearing in this server.')
	} 
});

//bot hi
client.on('message', message => {
	if (message.content === 'hi bot') {
		message.channel.send('Hi there', message.author)
	}
});


//welcome
client.on('guildMemberAdd', member => {
	const channel = member.guild.channels.find('name', 'member-log');
	if (!channel) return;
	channel.send(`Welcome to the server, ${member}`);
});


client.login(token);