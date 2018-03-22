const Discord = require('discord.js');
const client = new Discord.Client();
const token = require('./auth.json');

client.on('ready', () => {
	console.log('I am ready!');
});

// message (command)
client.on('message', message => {
	if (message.content === 'p!ping') {
		message.channel.send('pong');
	}
});

//bot 1 (command)
client.on('message', message => {
	if (message.content === 'p!owner') {
		message.channel.send('Well, lets see. I think my owners discord Machiko#9793. Feel free to write to him!')
	} 
});

//No swearing (beta testing)
client.on('message', message => {
	if (message.content === 'fuck') {
		message.channel.send('No swearing in this server.')
	} 
});

//bot hi (start on interaction)
client.on('message', message => {
	if (message.content === 'hi bot') {
		message.channel.send('Hi there, I have not much to say right now. But I will feature A.I. later on. So you will be able to have a conversation with me!')
	}
});


//welcome (Not working)
client.on('guildMemberAdd', member => {
	const channel = member.guild.channels.find('name', 'member-log');
	if (!channel) return;
	channel.send('Welcome to the server!');
});


client.login(token.token);