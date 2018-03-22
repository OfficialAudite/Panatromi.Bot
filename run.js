const Discord = require('discord.js');
const client = new Discord.Client();
const token = require('./auth.json');
var x = 0;

client.on('ready', () => {
	client.user.setStatus('online')
	client.user.setGame('Pre-Alpha 8/9 | p!help')
		.then(console.log)
		.catch(console.error);
		console.log('Bot is running!');
});

//1.1 help
client.on('message', message => {
	if (message.content === 'p!help') {
		message.channel.send('**Basic** \n`p!owner`, `p!ping`, `p!help`, `hi bot`, `p!vote`, `p!meow`');
	}
});
	
//1.2 message
client.on('message', message => {
	if (message.content === 'p!ping') {
		message.channel.send('pong');
	}
});

//1.3 vote care
client.on('message', message => {
	if (message.content === 'p!vote') {
		message.react('👍');
		message.react('👎');
		message.react('👐');
	}
});

//1.4 bot 1
client.on('message', message => {
	if (message.content === 'p!owner') {
		message.channel.send('Well, lets see. I think my owners discord Machiko#9793. Feel free to write to him!')
	} 
});

//1.5 No swearing
client.on('message', message => {
	if (message.content === 'fuck') {
		message.channel.send('No swearing in this server.')
	} 
});

//1.6 bot hi 
client.on('message', message => {
	if (message.content === 'hi bot') {
		message.channel.send('Hi there, I have not much to say right now. But I will feature A.I. later on. So you will be able to have a conversation with me!')
	}
});


//1.7 welcome (not working)
client.on('guildMemberAdd', member => {
	const channel = member.guild.channels.find('name', 'member-log');
	if (!channel) return;
	channel.send('Welcome to the server!');
});

//1.8 meow counter
client.on('message', message => {
	if (message.content === 'meow') {
		x++;
	} 
});

//1.9 meow counter show
client.on('message', message => {
	if (message.content === 'p!meow') {
	message.channel.send("I have counted **"+ x +"** meows globaly!");
	message.react('🐱');
	} 
});

client.login(token.token);