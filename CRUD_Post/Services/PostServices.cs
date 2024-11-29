using CRUD_Post.Models;

namespace CRUD_Post.Services;

public class PostServices
{
    private List<Post> posts;

    public PostServices()
    {
        posts = new List<Post>();
    }

    public Post AddPost(Post post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);

        return post;
    }

    public bool Delete(Guid id)
    {
        foreach (Post post in posts)
        {
            if (post.Id == id)
            {
                posts.Remove(post);
                return true;
            }
        }
        return false;
    }

    public bool Update(Post updatingpost)
    {
        for (var i = 0; i < posts.Count; i++)
        {
            if (posts[i].Id == updatingpost.Id)
            {
                posts[i] = updatingpost;
                return true;
            }
        }
        return false;
    }

    public Post GetById(Guid id)
    {
        foreach (Post post in posts)
        {
            if (post.Id == id)
            {
                return post;
            }
        }
        return null;
    }
    public List<Post> GetPosts()
    {
        return posts;
    }
    public Post GetMostViewedPost()
    {
        var mostViewedPost = new Post();
        var viewsOfPost = 0;
        foreach (var post in posts)
        {
            if (post.Comments.Count > viewsOfPost)
            {
                viewsOfPost = post.Comments.Count;
                mostViewedPost = post;
            }
        }
        return mostViewedPost;
    }

    public Post GetMostLikedPost()
    {
        var mostLikedPost = new Post();
        var likesOfPost = int.MinValue;
        foreach (var post in posts)
        {
            if (post.QuantityLinkes > likesOfPost)
            {
                likesOfPost = post.QuantityLinkes;
                mostLikedPost = post;
            }
        }
        return mostLikedPost;
    }

    public Post GetMostCommentedPost()
    {
        var mostCommentedPost = new Post();
        var amountOfComments = int.MinValue;
        foreach (var post in posts)
        {
            if (post.Comments.Count > amountOfComments)
            {
                amountOfComments = post.Comments.Count;
                mostCommentedPost = post;
            }
        }
        return mostCommentedPost;
    }

    public List<Post> GetPostsByComment(string comment)
    {
        var postsByComment = new List<Post>();
        foreach (var post in posts)
        {
            if (post.Comments.Contains(comment) is true)
            {
                postsByComment.Add(post);
            }
        }

        return postsByComment;
    }

    public bool AddViewerName(string name, Guid postId)
    {
        var post = GetById(postId);
        if (post != null)
        {
            return false;
        }
        post.ViewerNames.Add(name);

        return true;
    }
    public bool AddComment(string comment, Guid postId)
    {
        var post = GetById(postId);
        if (post is null)
        {
            return false;
        }
        post.Comments.Add(comment);

        return true;
    }
    public bool AddLike(Guid postId)
    {
        var post = GetById(postId);
        if (post is null)
        {
            return false;
        }
        post.QuantityLinkes += 1;
        return true;
    }

}
