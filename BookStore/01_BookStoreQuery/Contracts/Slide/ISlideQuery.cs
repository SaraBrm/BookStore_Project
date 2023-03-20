using System.Collections.Generic;

namespace _01_BookStoreQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
