﻿using System;
using System.Collections.Generic;
using System.Linq;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsMasochist : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Masochist"; } }
        public string SeedFileString { get { return "M{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} M{1}"; } }

        public void ResetLocations()
        {
           Locations = new List<Location>
                       {
                           new Location
                               {
                                   NoHidden = false, //ok
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria surface)",
                                   Address = 0x781CC,
                                   CanAccess =
                                       have =>
                                   	CanIbj(have)
									&& CanUsePowerBombs(have),
                               },
                           new Location
                               { 
                                   NoHidden = false, //ok							   
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Underwater outside Wrecked Ship)",
								   //originally 0x781E8
                                   Address = 0x7EEAC,
                                   CanAccess =
                                       have => 
									CanAccessWs(have),
                               },
                           new Location
                               {     
                                   NoHidden = false,//ok
                                   GravityOkay = false,                                   
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship top)",
								   //0x781EE
                                   Address = 0x7EEB2,
                                   CanAccess =
                                       have =>
                                    CanAccessWs(have),
                               },
                           new Location
                               {       
                                   NoHidden = false,	//ok
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Missile (outside WS under super block)",
								   //0x781F4
                                   Address = 0x7EEB8,
                                   CanAccess =
                                       have => 
                                    CanAccessWs(have),
                               },
                           new Location
                               {        
                                   NoHidden = true,//
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria moat)",
                                   Address = 0x78248,
                                   CanAccess =
                                       have =>
                                       CanAccessWs(have),
                               },
                           new Location
                               {       
                                   NoHidden = true,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria gauntlet)",
								   //0x78264
                                   Address = 0x7846A,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have),
                               },
                           new Location
                               {        
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Bomb",
                                   Address = 0x78404,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
									   && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {     
                                   NoHidden = true,	
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria terminator)",
                                   Address = 0x78432,
                                   CanAccess = 
                                       have => 
                                   	CanEnterPassages(have)
                                   	|| CanSpeedball(have),
                               },
                            new Location
                               {        
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria old MB missiles)",
								   //0x783EE
                                   Address = 0x7F39E,
                                   CanAccess =
                                       have => 
                                   	//screw bombs pb and speedboost
                                   	have.Contains(ItemType.MorphingBall)
                                   	&& CanDestroyBombBlocks(have),
                               },
                           new Location
                               {       
                                   NoHidden = false,	
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria 2st gauntlet missiles)",
                                   Address = 0x78464,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have),
                               },
                           new Location
                               {     
                                   NoHidden = true,	
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria 1st gauntlet missiles)",
								   //0x7846A-is crateria etank or 0x78264
                                   //Address = 0x78464,
                                   Address= 0x78264,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have),
                               },
                           new Location
                               {     
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria supers)",
                                   Address = 0x78478,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
									   && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {       
                                   NoHidden = false,	
                                   GravityOkay = false,     
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria Final Missiles)",
                                   Address = 0x78486,
                                   CanAccess =
                                       have =>
                                       CanEnterPassages(have)
									   || (CanSpeedball(have)
                                   	&& have.Contains(ItemType.SpringBall)),
                               },
							   new Location
                               {        
                                   NoHidden = false,	
                                   GravityOkay = false,     
                                   Region = Region.Crateria,
                                   Name = "missile (Crateria Map Station Missiles)",
								   //Map missiles #1
                                   Address = 0x78444,
                                   CanAccess =
                                       have =>
                                   	CanOpenMissileDoors(have),
                               },
                           new Location
                               {        
                                   NoHidden = false,	
                                   GravityOkay = false,
                                   Region = Region.GreenBrinstar,
                                   Name = "Power Bomb (Brinstar Etecoons)",
                                   Address = 0x784AC,
                                   CanAccess =
                                       have => 
                                   	CanMeetEtecoons(have),
                                   //Backflip method
                                       //CanEnterPassages(have)
									   //&& have.Containts(ItemType.morphingball),
                               },
                           new Location
                               {        
                                   NoHidden = true,	
                                   GravityOkay = false,  
                                   Region = Region.PinkBrinstar,
                                   Name = "Super Missile (Spospo Supers)",
								   //0x784E4
                                   Address = 0x7F31C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have => //I might leave this item unrandomized for the sake of not having softlocks
                                       CanAccessPinkBrinstar(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {            
                                   NoHidden = true,
                                   GravityOkay = false, 
                                   Region = Region.GreenBrinstar,
                                   Name = "Missile (Brinstar below Early Supers)",
                                   Address = 0x78518,
                                   CanAccess =
                                       have =>
                                       CanAccessGreenBrinstar(have)
                                       && CanOpenMissileDoors(have),
									   //canbackflip to remove morphball req
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,   
                                   Region = Region.GreenBrinstar,
                                   Name = "Super Missile (Brinstar Early Supers)",
                                   Address = 0x7851E,
                                   CanAccess =
                                       have =>
                                       CanAccessGreenBrinstar(have)
                                       && CanOpenMissileDoors(have)
                                   	&& have.Contains(ItemType.MorphingBall),
									   //missiles+morph only
                               },
                           new Location
                               {           
                                   NoHidden = true,	
                                   GravityOkay = false,   
                                   Region = Region.GreenBrinstar,
                                   Name = "Reserve Tank (Brinstar Reserve)",
                                   Address = 0x7852C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessGreenBrinstar(have)
                                       && CanOpenMissileDoors(have)
                                   	&& have.Contains(ItemType.MorphingBall),
									   //missiles+morph only
                               },
                           new Location
                               {            
                                   NoHidden = true,	
                                   GravityOkay = false,   
                                   Region = Region.GreenBrinstar,
                                   Name = "Missile (Brinstar Reserve Ron Popeil Missiles)",
                                   Address = 0x78532,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessGreenBrinstar(have)
                                       && CanOpenMissileDoors(have)
									   && (CanSpeedball(have)
									   || CanEnterPassages(have)),
                               },
                           new Location
                               {             
                                   NoHidden = false,	
                                   GravityOkay = false,  
                                   Region = Region.GreenBrinstar,
                                   Name = "Missile (Brinstar Reserve Missiles)",
                                   Address = 0x78538,
                                   CanAccess =
                                       have =>
                                       CanAccessGreenBrinstar(have)
                                       && CanOpenMissileDoors(have)
                                   	&& have.Contains(ItemType.MorphingBall),
									   //missiles+morph only
                               },
                           new Location
                               {             
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.PinkBrinstar,
                                   Name = "Missile (Big Pink Brinstar top)",
                                   Address = 0x78608,
                                   CanAccess =
                                       have =>
                                       CanAccessPinkBrinstar(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.PinkBrinstar,
                                   Name = "Missile (Big Pink Brinstar Charge Missiles)",
                                   Address = 0x7860E,
                                   CanAccess =
                                       have =>
                                   	CanAccessPinkBrinstar(have),
                               },
                           new Location
                               {             
                                   NoHidden = true,	
                                   GravityOkay = false,      
                                   Region = Region.PinkBrinstar,
                                   Name = "Charge Beam",
                                   Address = 0x78614,
                                   CanAccess =
                                       have =>
                                   	CanAccessPinkBrinstar(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,     
                                   Region = Region.PinkBrinstar,
                                   Name = "Power Bomb (Pink Brinstar Power Bombs)",
								   //0x7865C
                                   Address = 0x7F232,
                                   CanAccess =
                                       have =>
                                       CanAccessPinkBrinstar(have)
                                   	&& CanUsePowerBombs(have),
                              },
                           //where is the pink brinstar etank???
                           new Location
                               {           
                                   NoHidden = true,	
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar Pipe Missiles)",
                                   Address = 0x78676,
                                   CanAccess =
                                       have =>
                                   	//can also speedball+beam from under first missiles to get here
                                   	(CanEnterPassages(have)
                                   	 || CanSpeedball(have))
                                   	|| CanAccessPinkBrinstar(have),
                               },
                           new Location
                               {           
                                   NoHidden = true,
                                   GravityOkay = false,              
                                   Region = Region.Brinstar,
								   //This slot changes according to what can and can't be obtained in the randomizer.
                                   Name = "Morphing Ball",   						   
                                   Address = 0x786DE,
                                   CanAccess = 
                                       have => 
                                   	true,
                               },
                           new Location
                               {              
                                   NoHidden = true,	
                                   GravityOkay = false,      
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (Blue Brinstar)",
                                   Address = 0x7874C,
                                   CanAccess =
                                       have => 
                                   	//needs the roomstate to change for the item to appear
                                   	CanUsePowerBombs(have),
                               },
                           new Location
                               {              
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (Blue Brinstar middle)",
								   //0x78798
                                   Address = 0x7EBB8,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
									   && have.Contains(ItemType.MorphingBall)
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Blue Brinstar)",
								   //0x7879E
                                   Address = 0x7EBBE,
                                   CanAccess =
                                       have =>
                                   	CanOpenMissileDoors(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,  
                                   Region = Region.GreenBrinstar,
                                   Name = "Energy Tank (Brinstar near Etecoons E-tank)",
								   //0x787C2
                                   Address = 0x7F4F2,
                                   CanAccess =
                                       have => 
                                   	CanMeetEtecoons(have),
                                   //Backflip method
                                       //CanEnterPassages(have)
									   //&& have.Containts(ItemType.morphingball),
                               },
                           new Location
                               {            
                                   NoHidden = false,	
                                   GravityOkay = false,    
                                   Region = Region.GreenBrinstar,
                                   Name = "Super Missile (Brinstar near Etecoons)",
								   //0x787D0
                                   Address = 0x7F9CC,
                                   CanAccess =
                                       have =>
                                   	CanMeetEtecoons(have),
									   //|| CanEnterPassages is the backflip method
                               },
                           new Location
                               {          
                                   NoHidden = true,	
                                   GravityOkay = false,    
                                   Region = Region.PinkBrinstar,
                                   Name = "Energy Tank (Pink Brinstar under Charge Beam)",
                                   Address = 0x787FA,
                                   CanAccess =
                                       have =>
                                   	CanAccessPinkBrinstar(have)
                                   	&& CanUsePowerBombs(have)
                                   	&& have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {            
                                   NoHidden = true,	
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (Blue Brinstar First Missiles)",
								   //0x78802
                                   Address = 0x7EAC8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess = 
                                       have => 
                                   	have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {             
                                   NoHidden = false,	
                                   GravityOkay = false,     
                                   Region = Region.PinkBrinstar,
                                   Name = "Energy Tank (Pink Brinstar Hoppers Room)",
                                   Address = 0x78824,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
									   && have.Contains(ItemType.WaveBeam)
                                   	&& CanAccessPinkBrinstar(have),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (Blue Brinstar upper Billy Mays)",
								   //0x78836
                                   Address = 0x7EBC4,
                                   CanAccess =
                                       have =>
                                   	CanOpenMissileDoors(have)
                                   	&& CanDestroyBombBlocks(have)
                                   	&& have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Missile (Blue Brinstar lower Billy Mays)",
								   //0x7883C
                                   Address = 0x7EBCA,
                                   CanAccess =
                                       have =>
                                   	CanOpenMissileDoors(have)
                                   	&& have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,      
                                   Region = Region.RedBrinstar,
                                   Name = "X-Ray Visor",
                                   Address = 0x78876,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                   	(CanAccessPinkBrinstar(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && have.Contains(ItemType.MorphingBall))
                                   	//lots of spikes, might need grapple/space/speedboost for casuals
									   || (have.Contains(ItemType.GrappleBeam)
                                   	    && CanAccessRedBrinstar(have)
                                   	    && CanUsePowerBombs(have)),
                               },
                           new Location
                               {           
                                   NoHidden = true,
                                   GravityOkay = false,            
                                   Region = Region.RedBrinstar,
                                   Name = "Power Bomb (Beta Power Bomb Room)",
                                   Address = 0x788CA,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && have.Contains(ItemType.SuperMissile)
									   && CanUsePowerBombs(have),
                               },
                           new Location
                               {            
                                   NoHidden = true,
                                   GravityOkay = false,        
                                   Region = Region.RedBrinstar,
                                   Name = "Power Bomb (Alpha Power Bomb Room)",
                                   Address = 0x7890E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && (have.Contains(ItemType.SuperMissile)
									   || (have.Contains(ItemType.SuperMissile)
                                   	        && CanUsePowerBombs(have))),
                               },
                           new Location
                               {              
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.RedBrinstar,
                                   Name = "Missile (Alpha Power Bomb Room)",
                                   Address = 0x78914,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && (have.Contains(ItemType.SuperMissile)
									   || (have.Contains(ItemType.SuperMissile)
                                   	        && CanUsePowerBombs(have))),
                               },
                           new Location
                               {     
								NoHidden = false,
                                   GravityOkay = false, 
                                   Region = Region.RedBrinstar,
                                   Name = "Spazer",
                                   Address = 0x7896E,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {           
									NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Kraid,
                                   Name = "Energy Tank (Kraid)",
								   //0x7899C
                                   //Address = 0x7FC8A, //ADDRESS UPDATE
                                   Address = 0x7FC8A,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have),
                               },
                           new Location
                               {           
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Kraid,
                                   Name = "Missile (Kraid)",
								   //0x789EC
                                   //Address = 0x7FC05, //ADDRESS UPDATE
                                   Address = 0x7FC06,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Kraid,
                                   Name = "Varia Suit",
								   //0x78ACA
                                   Address = 0x7F150,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
										|| (CanAccessHeatedNorfair(have)
                                       && CanUsePowerBombs(have))
                                   	|| (CanAccessRedBrinstar(have)
                                   	&& (CanOpenMissileDoors(have)
                                   	        && (have.Contains(ItemType.MorphingBall)
                                   	            || have.Contains(ItemType.SpeedBooster)))),
                                   
                                   	       // || have.Contains(ItemType.SpeedBooster))),
                                   	    //speedbooster is a bit technical
									   
									   //CanBackdoor with varia
									   //CanBackdoor with missiles+morph via maridia corridor
                               },
							   new Location
                               {            
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.GreenBrinstar,
								   //Map Missiles #2
                                   Name = "missile (Brinstar Map Station Missiles)",
                                   Address = 0x7F9C6,
                                   CanAccess =
                                       have =>
                                   	CanAccessGreenBrinstar(have)
                                   	&& CanOpenMissileDoors(have),
                               },
                           new Location
                               {              
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Cathedral Missiles)",
								   //0x78AE4
                                   Address = 0x7F600,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& EnergyReserveCount(have) >= 3,
                                   //short hellrun --semi tas like is 200 health
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Ice Beam",
                                   Address = 0x78B24,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& EnergyReserveCount(have) >= 3,
                                   //short hellrun
                               },
                           new Location
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Left Grapple Missiles)",
								   //0x78B46
                                   Address = 0x7EFA6,
                                   CanAccess =
                                       have =>
                                       CanAccessIceBeam(have)
                                   || (CanAccessCrocomire(have)//short hellrun
                                       || CanAccessLowerNorfair(have)),
                                   //can defeat either Crocomire or Ridley+enter passages
                               },
                           new Location
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Crocomire)",
								   //0x78BA4
                                   Address = 0x7F5D6,
                                   CanAccess =
                                       have =>
                                       (CanAccessIceBeam(have)
                                   	&& CanEnterPassages(have))//almost or no hellrun
                                   || (CanAccessCrocomire(have)//short hellrun
                                       || CanAccessLowerNorfair(have)),
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Hi-Jump Boots",
                                   Address = 0x78BAC,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.MorphingBall),//no hellrun
                               },
                           new Location
                               {                   
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Crocomire Escape)",
								   //0x78BC0
                                   Address = 0x7FE1A,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have),//20 energy hellrun??
                               },
                           new Location
                               {                   
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Hi-Jump Boots)",
                                   Address = 0x78BE6,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.MorphingBall),//no hellrun
                               },
                           new Location
                               {                    
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Hi-Jump Boots)",
                                   Address = 0x78BEC,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.MorphingBall),//no hellrun
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Grapple Power Bombs)",
								   //0x78C04
                                   Address = 0x7FCC6,
                                   CanAccess =
                                       have =>
                                   	((CanAccessIceBeam(have)
                                   	&& CanEnterPassages(have))//almost or no hellrun
                                   || CanAccessCrocomire(have)//short hellrun
                                   	    || CanAccessLowerNorfair(have)),
                                   //Can backdoor via backflip+morph
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Crocomire)",
								   //0x78C14
                                   Address = 0x78BA4,
                                   CanAccess =
                                       have =>
                                   	CanAccessCrocomire(have), //crocomire etank is replaced by missiles
                               },
                           new Location
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Right Grapple Missiles)",
								   //0x78C2A
                                   Address = 0x7FCC0,
                                   CanAccess =
                                       have =>
                                       ((CanAccessIceBeam(have)
                                   	&& CanEnterPassages(have))//almost or no hellrun
                                   || CanAccessCrocomire(have)//short hellrun
                                   	    || CanAccessLowerNorfair(have)),
                                   //Can backdoor via backflip+morph near crocomire exit
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Grapple Beam",
								   //0x78C36
                                   Address = 0x7EFA0,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       ((CanAccessIceBeam(have)
                                   	&& CanEnterPassages(have))//almost or no hellrun
                                   || CanAccessCrocomire(have)//short hellrun
                                   	    || CanAccessLowerNorfair(have)),
                                   //Can backdoor via backflip+morph near crocomire exit
                               },
                           new Location
                               {                  
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Reserve Tank (Norfair Reserves)",
								   //0x78C3E
                                   Address = 0x7F648,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                   	//bubble mountain hellrun is about 300 energy with decent movement
                                   	CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {                  
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair Reserves 2nd Missiles)",
								   //0x78C44
                                   Address = 0x7F642,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {                 
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair Reserves 1st Missiles)",
								   //0x78C52
                                   Address = 0x7F63C,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.SuperMissile)
                                   	&& EnergyReserveCount(have) >= 3,
                               },
                           new Location
                               {                       
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Bubble Mountain)",
								   //0x78C66
                                   Address = 0x78166,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& EnergyReserveCount(have) >= 3,
                               },
                           new Location
                               {                     
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Speed Booster)",
                                   Address = 0x78C74,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                   	(CanAccessRedBrinstar(have)//2 main routes to speedboost, kraid backdoor or business center
                                   	 && have.Contains(ItemType.SuperMissile)
                                   	&& EnergyReserveCount(have) >= 4)
                                   	|| (CanDefeatKraid(have)
                                   	    && CanUsePowerBombs(have)
                                   	   && EnergyReserveCount(have) >= 4),
                               },
                           new Location
                               {                     
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Speed Booster",
                                   Address = 0x78C82,
                                   CanAccess =
                                       have =>
                                       (CanAccessRedBrinstar(have)//2 main routes to speedboost, kraid backdoor or business center
                                   	 && have.Contains(ItemType.SuperMissile)
                                   	&& EnergyReserveCount(have) >= 4)
                                   	|| (CanDefeatKraid(have)
                                   	    && CanUsePowerBombs(have)
                                   	   && EnergyReserveCount(have) >= 4),
                               },
                           new Location
                               {                      
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Wave/LN Escape Missiles)",
								   //0x78CBC
                                   Address = 0x7816C,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Wave Beam",
								   //0x78CCA
                                   Address = 0x78172,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& CanOpenMissileDoors(have),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Gold Torizo)",
                                   Address = 0x78E6E,
                                   CanAccess =
                                       have =>
                                   	CanAccessLowerNorfair(have)
                                   	&& CanUsePowerBombs(have)
                                   	&& have.Contains(ItemType.ChargeBeam),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Super Missile (Gold Torizo)",
                                   Address = 0x78E74,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                   	&& CanUsePowerBombs(have)
                                   	&& have.Contains(ItemType.ChargeBeam),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Mickey Mouse)",
                                   Address = 0x78F30,
                                   CanAccess =
                                       have =>
                                   	CanAccessLowerNorfair(have)
                                   	&& CanUsePowerBombs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Lower Norfair Spring Ball Maze)",
                                   Address = 0x78FCA,
                                   CanAccess =
                                       have =>
                                   	CanAccessLowerNorfair(have)
                                   	&& CanEnterPassages(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (Lower Norfair Spring Ball Maze)",
                                   Address = 0x78FD2,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                   	&& CanEnterPassages(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (Power Bombs of Shame)",
                                   Address = 0x790C0,
                                   CanAccess =
                                       have =>
                                   	CanAccessLowerNorfair(have)
                                   	&& CanEnterPassages(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (FrankerZ)",
                                   Address = 0x79100,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                   	&& CanDestroyBombBlocks(have)
                                   	&& have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Ridley)",
								   //0x79108
                                   Address = 0x7EA78,
                                   CanAccess =
                                       have =>
                                   	CanAccessLowerNorfair(have)
                                   	&& CanUsePowerBombs(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Screw Attack",
                                   Address = 0x79110,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                   	&& CanUsePowerBombs(have),
                               },
                           new Location
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Lower Norfair Fire Flea E-tank)",
                                   Address = 0x79184,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship Spike Room)",
                                   Address = 0x7C265,
                                   CanAccess =
                                       have => 
                                   	CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Reserve Tank (Wrecked Ship Reserves)",
                                   Address = 0x78A9E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                   	CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship Reserves)",
                                   Address = 0x78AA4,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                          
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship Attic)",
                                   Address = 0x7C231,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Energy Tank (Wrecked Ship)",
                                   Address = 0x7C337,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship left)",
                                   Address = 0x7C357,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship right)",
                                   Address = 0x7C365,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Gravity Suit",
                                   Address = 0x78A86,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
							   
							new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
								   //Map Missiles #3
                                   Name = "missile (Wrecked Ship Map Station Missiles)",
                                   Address = 0x7C34D,
								   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have)
                                   	&& CanIbj(have),

                               },   
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia Main Street)",
								   //0x7C437
                                   Address = 0x7C437,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& CanUsePowerBombs(have)
                                   	&& have.Contains(ItemType.GravitySuit)
                                   	&& have.Contains(ItemType.SpeedBooster),
                                   	
                               },
                           new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (Maridia Crab Supers)",
                                   Address = 0x7C43D,
                                   CanAccess =
                                   		have =>
                                   	CanAccessMaridiaSpeedrunner(have)
                                   	&& CanUsePowerBombs(have),
                                       
                               },
                           new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Maridia Turtles)",
                                   Address = 0x7C47D,
                                   CanAccess =
                                       have =>
                                   	CanAccessMaridiaSpeedrunner(have)
                                   	&& have.Contains(ItemType.GrappleBeam),
                               },
                           new Location
                               {                            
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia Turtles)",
                                   Address = 0x7C483,
                                   CanAccess =
                                       have =>
                                   	CanAccessMaridiaSpeedrunner(have),
                               },
                           new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (Maridia Watering Hole Supers)",
								   //0x7C4AF
                                   Address = 0x7F196,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have)
                                   	&& have.Contains(ItemType.GravitySuit),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia Watering Hole Missiles)",
								   //0x7C4B5
                                   Address = 0x7F19C,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia Beach Missiles)",
								   //0x7C533
                                   Address = 0x7C515,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Plasma Beam",
                                   Address = 0x7C559,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridiaSpeedrunner(have)
                                   	&& have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia left sand pit room)",
                                   Address = 0x7FECB,
                                   CanAccess =
                                       have =>
                                   	CanAccessAquaductSpeedrunner(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Reserve Tank (Maridia Reserves)",
                                   Address = 0x7FEC5,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                   	CanAccessAquaductSpeedrunner(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia right sand pit room)",
                                   Address = 0x7FED1,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (Maridia right sand pit room)",
                                   Address = 0x7FED7,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have),
                               },
                           new Location
                               {                            
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Aqueduct Missiles)",
								   //0x7C603
                                   Address = 0x7FEB9,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have)
                                   	&& have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (Aqueduct Supers)",
								   //0x7C609
                                   Address = 0x7FEBF,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have)
                                   	&& have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Spring Ball",
                                   Address = 0x7C6E5,
                                   CanAccess =
                                       have =>
                                   	CanAccessMaridiaSpeedrunner(have),
                               },
                           new Location
                               {                            
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon)",
                                   Address = 0x780D2,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have)
                                   	&& have.Contains(ItemType.ChargeBeam)
                                   	&& have.Contains(ItemType.GrappleBeam),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Botwoon)",
								   //0x7C755
                                   Address = 0x7C79F,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have)
                                   	&& have.Contains(ItemType.ChargeBeam),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Space Jump",
								   //0x7C7A7
                                   Address = 0x7C791,
                                   CanAccess =
                                       have =>
                                       CanAccessAquaductSpeedrunner(have)
                                   	&& have.Contains(ItemType.ChargeBeam)
                                   	&& have.Contains(ItemType.GrappleBeam),
                               },
							   new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
								   //Map Missiles #4
                                   Name = "missile (Maridia Map Station Missiles - Corridor)",
                                   Address = 0x7C581,
                                   CanAccess =
                                       have =>
                                   	CanAccessRedBrinstar(have),
                               },
                       };
        }
         private static bool CanUsePowerBombs(List<ItemType> have)
        {
            return have.Contains(ItemType.PowerBomb) 
                && have.Contains(ItemType.MorphingBall);
		}
		private static bool CanAccessWs(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile) 
                && CanUsePowerBombs(have);
		}
		
        private static bool CanEnterAndLeaveGauntlet(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Count(x => x == ItemType.PowerBomb) >= 2 
        	            && have.Contains(ItemType.MorphingBall))
        	        || have.Contains(ItemType.ScrewAttack);
        }	
        private static bool CanOpenPassages(List<ItemType> have)
        {

			return (have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb))
				|| CanUsePowerBombs(have)
				|| have.Contains(ItemType.ScrewAttack);
		}
		
        private static bool CanEnterPassages(List<ItemType> have)
        {
			return (have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb))
				|| CanUsePowerBombs(have);
		}
		
        private static bool CanDestroyBombBlocks(List<ItemType> have)
        {
        	return (have.Contains(ItemType.MorphingBall)
        	        && (have.Contains(ItemType.Bomb)
        	            || have.Contains(ItemType.PowerBomb))
        	        || have.Contains(ItemType.SpeedBooster)
        	        || have.Contains(ItemType.ScrewAttack));
		}
		
		private static bool CanSpeedball(List<ItemType> have)
		{
			return (have.Contains(ItemType.SpeedBooster)
				&& have.Contains(ItemType.MorphingBall));
		}

		private static bool CanOpenMissileDoors(List<ItemType> have)
		{
			return (have.Contains(ItemType.Missile)
				|| have.Contains(ItemType.SuperMissile));
		}
		private static bool CanAccessRedBrinstar(List<ItemType> have)
		{
			//3 possible routes to enter Red Brinstar
			return (have.Contains(ItemType.SuperMissile)
				&& (CanEnterPassages(have) //cannot have a circular argument-list individual items
			            || (CanUsePowerBombs(have)))
				&& have.Contains(ItemType.SuperMissile))
				|| (have.Contains(ItemType.MorphingBall)
				&& have.Contains (ItemType.SuperMissile));
		}		
		private static bool CanAccessGreenBrinstar(List<ItemType> have)
		{
			//2 possible routes to enter Green Brinstar
			return CanEnterPassages(have) //cannot have circular arguments-list individual items
				|| (CanUsePowerBombs(have)
				&& have.Contains(ItemType.SuperMissile))
				|| (have.Contains(ItemType.MorphingBall)
				&& have.Contains (ItemType.SuperMissile));;
		}
		private static bool CanAccessPinkBrinstar(List<ItemType> have)
		{
			//2 possible routes to enter Pink Brinstar
			return CanSpeedball(have)
				|| CanEnterPassages(have)
				|| CanAccessRedBrinstar(have)
				|| (CanAccessGreenBrinstar(have)
				&& CanOpenMissileDoors(have));
		}			        
		
		private static bool CanDefeatKraid(List<ItemType> have)
		{
			return CanAccessRedBrinstar(have)
				&& CanEnterPassages(have)
				&& CanOpenMissileDoors(have);
		}
		
		private static bool CanAccessHeatedNorfair(List<ItemType> have)
		{
			return CanAccessRedBrinstar(have)
			&& (have.Contains(ItemType.VariaSuit)
				|| have.Contains(ItemType.GravitySuit));
		}
		private static bool CanAccessIceBeam(List<ItemType> have)
		{
			return CanAccessRedBrinstar(have)
			&& (have.Contains(ItemType.SuperMissile) //semishort hellrun, with non hellrun exit
				    && EnergyReserveCount(have) >= 3) //--200 health hellrun
				|| CanUsePowerBombs(have);
		}	
		private static bool CanAccessCrocomire(List<ItemType> have)
		{
			return CanAccessRedBrinstar(have) //baby mode -lava dive route
			&& (have.Contains(ItemType.SuperMissile) //semishort hellrun, with non hellrun exit
				    && have.Contains(ItemType.SpeedBooster)
				   && EnergyReserveCount(have) >= 3); //200 health hellrun
		}	
		private static bool CanAccessLowerNorfair(List<ItemType> have)
		{
			return CanAccessHeatedNorfair(have)
				&& have.Contains(ItemType.ChargeBeam)
				&& EnergyReserveCount(have) >= 4
				&& have.Contains(ItemType.GravitySuit) //Route 1 - normal entrance
						//can do lava dive, gravity jump||lava spark w/gravity
				|| (CanEnterPassages(have) //backdoor method
			&& EnergyReserveCount(have) >= 4);
		}	
		private static bool CanAccessMaridiaSpeedrunner(List<ItemType> have)
		{
			return CanAccessRedBrinstar(have)
				&& CanIbj(have)
				&& EnergyReserveCount(have) >= 4;
		}	
		
		private static bool CanAccessAquaductSpeedrunner(List<ItemType> have)
		{
			return CanAccessMaridiaSpeedrunner(have)
				&& have.Contains(ItemType.ChargeBeam)
				&& (have.Contains(ItemType.SpeedBooster));
		}	
		private static bool CanIbj(List<ItemType> have)
		{
			return have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb);
		}	
		private static bool CanMeetEtecoons(List<ItemType> have)
		{
			return CanAccessGreenBrinstar(have)
				&& ((CanEnterPassages(have)
				    && have.Contains(ItemType.MorphingBall))
				|| (CanSpeedball(have)
				        && have.Contains(ItemType.SpringBall)));
				
		}	
        private static int EnergyReserveCount(List<ItemType> have)
        {
            var energyTankCount = have.Count(x => x == ItemType.EnergyTank);
            var reserveTankCount = Math.Min(have.Count(x => x == ItemType.ReserveTank), energyTankCount + 1);
            return energyTankCount + reserveTankCount;
        }

        public RomLocationsMasochist()
        {
            ResetLocations();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
			// only try gravity if gravity is okay in this spot
			// only insert multiples of an item into the candidate list if we aren't looking at the morph ball slot.
			if (!(candidateItem == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay)) && (currentLocations.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem)))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            int retVal;

            do
            {
                retVal = random.Next(currentLocations.Count);
            } while (insertedItem == ItemType.GravitySuit && !currentLocations[retVal].GravityOkay);

            return retVal;
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            ItemType retVal;

            do
            {
                retVal = itemPool[random.Next(itemPool.Count)];
            } while (retVal == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay));

            return retVal;
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
                       {
            	//30 items total:
            		//no plasma
            		//no gravity
            		//Speedbooster may be too powerful 
                           ItemType.MorphingBall,
                           ItemType.Bomb,
                           ItemType.ChargeBeam,
                           ItemType.ChargeBeam,
                           ItemType.ChargeBeam,
                           ItemType.ChargeBeam,
                           ItemType.Spazer,
                           ItemType.VariaSuit,
                           ItemType.HiJumpBoots,
                           ItemType.SpeedBooster,
                           ItemType.WaveBeam,
                           ItemType.GrappleBeam,
                           ItemType.SpringBall,
                           ItemType.IceBeam,
                           ItemType.XRayScope,
                           ItemType.ReserveTank,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                       };
        }
    }
}