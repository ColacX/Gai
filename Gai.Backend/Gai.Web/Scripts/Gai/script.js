console.log("script.js");
//http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/

var CharacterModel = {
	spriteImage: null,
}

var CharacterService = {
	draw: function (characterModel) {

	}


}

var CharacterClass = function (image) {
	this.x = 0.0;
	this.y = 0.0;

	this.image = image;
	this.row = 0;
	this.column = 0;
	this.animationStart = 0;
	this.animationEnd = 0;
	this.animationCounter = 0.0;
	this.animationSpeed = 1000.0;

	this.step = function (deltaTime) {
		this.animationCounter = this.animationCounter + deltaTime;

		if (this.animationCounter > this.animationSpeed) {
			this.animationCounter = 0.0;
			this.column++;

			if (this.column >= this.animationEnd) {
				this.column = this.animationStart;
			}
		}
	};

	this.draw = function (context) {
		var spriteW = 64;
		var spriteH = 64;
		var spriteX = this.x;
		var spriteY = this.y;
		var sx = (spriteW) * this.column;
		var sy = (spriteH) * this.row;

		context.drawImage(this.image, sx, sy, spriteW, spriteH, spriteX + 0.001, spriteY + 0.001, spriteW, spriteH);
	};

	this.walkUpAnimation = function () {
		this.row = 8;
		this.column = 0;
		this.animationStart = 1;
		this.animationEnd = 9;
		this.animationCounter = 0.0;
		this.animationSpeed = 100.0;
	};
	
	this.walkLeftAnimation = function () {
		this.row = 9;
		this.column = 0;
		this.animationStart = 1;
		this.animationEnd = 9;
		this.animationCounter = 0.0;
		this.animationSpeed = 100.0;
	};

	this.walkDownAnimation = function () {
		this.row = 10;
		this.column = 0;
		this.animationStart = 1;
		this.animationEnd = 9;
		this.animationCounter = 0.0;
		this.animationSpeed = 100.0;
	};

	this.walkRightAnimation = function () {
		this.row = 11;
		this.column = 0;
		this.animationStart = 0;
		this.animationEnd = 9;
		this.animationCounter = 0.0;
		this.animationSpeed = 1000.0;
	};

	this.stopAnimation = function () {
		this.animationStart = 0;
		this.animationEnd = 0;
		this.animationSpeed = 100.0;
	};

	this.walkRightAnimation();

	setTimeout(function () {

	}, 5000);
}

$(document).ready(function() {
	
	var lastTime = timestamp();
	var canvas = document.createElement("canvas");
	var context = canvas.getContext("2d");
	canvas.width = 1024;
	canvas.height = 1024;
	document.body.appendChild(canvas);
	
	var img = new Image();
	img.onload = function() {
		requestAnimationFrame(render);
	};
	img.src = "/Content/Gai/Images/character_default.png";

	var aiCharacter = new CharacterClass(img);
	var playerCharacter = new CharacterClass(img);
	
	
	function timestamp() {
		return window.performance && window.performance.now ? window.performance.now() : new Date().getTime();
	}
	
	function step(deltaTime){
		//console.debug("step");
		aiCharacter.step(deltaTime);
		//playerCharacter.step(deltaTime);
	}
	
	function draw(){
		//console.debug("draw");
		context.clearRect(0, 0, canvas.width, canvas.height);
		aiCharacter.draw(context);
		//playerCharacter.draw(context);
	}
	
	function render() {
		//console.debug("render");
		var currentTime = timestamp();
		var deltaTime = currentTime - lastTime;
		lastTime = currentTime;
		//console.debug(deltaTime);

		step(deltaTime);
		draw();
		
		requestAnimationFrame(render);
	}
	
});
