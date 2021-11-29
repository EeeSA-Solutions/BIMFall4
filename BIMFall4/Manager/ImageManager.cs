using BIMFall4.Data;
using BIMFall4.Migrations;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.Repeat
{
    public class ImageManager
    {
        public ImageDTO GetPictureByUserIdDTO(int id)
        {
            
            
            using(var db = new BIMFall4Context())
            {
                var image = db.Images.Where(x => x.UserID == id).FirstOrDefault();


                var newimage = new ImageDTO()
                {
                    ID = image.ID,
                    ImageURL = image.ImageURL,
                    Name = image.Name
                };

                return newimage;
                
            }
        }

        public void CreateImage(Image image)
        {
            using(var db = new BIMFall4Context())
            {
                var userImage = db.Images.FirstOrDefault();

                if(userImage != null)
                {
                    db.Images.Remove(userImage);
                    db.Images.Add(image);
                    db.SaveChanges();
                }
                else
                {
                    db.Images.Add(image);
                    db.SaveChanges();
                }

            }
        }
    }
}